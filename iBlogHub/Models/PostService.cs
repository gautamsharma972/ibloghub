using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using iBlogHub.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Models
{
    public class PostService : IPostsService
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _user;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<PostsInputModel> _logger;      
        public PostService(ApplicationDbContext db, 
            ICurrentUser user, 
            IHostingEnvironment hostingEnvironment,
            ILogger<PostsInputModel> logger)
        {
            _db = db;
            _user = user;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;           
        }

        public IList<TagsInput> Tags
        {
            get
            {
                var _tags = _db.Tags.
                Select(a => new TagsInput
                {
                    Id = a.Id,
                    Name = a.Name,
                    Slug = a.slug
                }).ToList();
                return _tags;
            }
        }

        public IList<PostsViewModel> FeaturedPosts
        {
            get
            {
                try
                {
                    var Featured = new List<PostsViewModel>();
                    var _featured = _db.Posts.
                        Include(a => a.Author).
                        ThenInclude(a => a.SocialProfiles).
                        Include(a => a.Category).
                        Where(a => a.isVerified && a.Status == PostStatus.Published && a.ViewsCount > 1000 && !a.Category.Title.Equals("Quotation")).ToList();
                    foreach (var posts in _featured)
                    {
                        Featured.Add(new PostsViewModel
                        {
                            Author = posts.Author,
                            CommentCount = posts.CommentCount,
                            CommentStatus = posts.CommentStatus,
                            Excerpt = posts.Excerpt,
                            FeaturedImage = posts.FeaturedImage,
                            Id = posts.Id,
                            ModifiedOn = posts.ModifiedOn,
                            PostContent = posts.PostContent,
                            PostDate = posts.PostDate,
                            PostTitle = posts.PostTitle,
                            slug = posts.slug,
                            Status = posts.Status,
                            isVerified = posts.isVerified,
                            ViewsCount = posts.ViewsCount,
                            Category = GetPostCategory(posts.Category),
                            Tags = GetPostsTags(posts.Id)
                        });
                    }

                    return Featured;
                }
                catch (Exception ex)
                {
                    return null;
                    //throw;
                }
            }
        }

        public async Task<ResultsModel> Create(PostsInputModel model)
        {
            ResultsModel result = new ResultsModel();
            try
            {
                var modelSlug = new slugGenerator().GenerateSlug(model.Title);
                var checkPost = await _db.Posts.Where(a => a.slug.Equals(modelSlug)).SingleOrDefaultAsync();
                if (checkPost != null)
                {
                    model.Message = "Post with same title already exists. Please create another.";
                    model.MessageClass = "danger";
                    result.Message = model.Message;
                    result.Success = false;
                    return result;
                }

                var _posts = new Data.Posts
                {
                    Author = _user.User,
                    CommentStatus = model.CommentStatus ? CommentStatus.Allowed : CommentStatus.Blocked,
                    Excerpt = model.Excerpt == null ? null : model.Excerpt.Trim(),
                    Id = Guid.NewGuid(),
                    FeaturedImage = model.FeaturedImage == null ? "" : SaveImage(model.FeaturedImage),
                    PostContent = model.Description,
                    PostDate = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    PostTitle = model.Title,
                    slug = new slugGenerator().GenerateSlug(model.Title.Trim()),
                    Status = model.PostStatus == "Publish" ? PostStatus.Published : PostStatus.Draft,
                    isVerified = false,
                    ViewsCount = 0
                };
                _db.Posts.Add(_posts);

                if (model.Category != null)
                {
                    var cid = Guid.Parse(model.Category);
                    var _PCat = _db.Categories.Where(a => a.Id == cid).FirstOrDefault();
                    _posts.Category = _PCat;
                }

                var PostsTagsRelations = new TagsPostsRelations();

                if (!string.IsNullOrEmpty(model.Tags))
                {
                    var tags = model.Tags.Split(",");
                    foreach (var tag in tags)
                    {
                        var checkTags = _db.Tags.Where(a => a.slug.ToLower().Equals(new slugGenerator().GenerateSlug(tag))).FirstOrDefault();
                        if (checkTags != null)
                        {
                            var tagPostsRelation = new TagsPostsRelations()
                            {
                                Id = Guid.NewGuid(),
                                Posts = _posts,
                                Tags = checkTags
                            };
                            _db.TagsPostsRelations.Add(tagPostsRelation);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            checkTags = new Tags
                            {
                                Id = Guid.NewGuid(),
                                Name = tag.ToLower().Trim(),
                                slug = new slugGenerator().GenerateSlug(tag)
                            };

                            _db.Tags.Add(checkTags);
                            //_ListTags.Add(checkTags);

                            var tagPostsRelation = new TagsPostsRelations()
                            {
                                Id = Guid.NewGuid(),
                                Posts = _posts,
                                Tags = checkTags
                            };
                            _db.TagsPostsRelations.Add(tagPostsRelation);
                            await _db.SaveChangesAsync();
                        }
                      
                    }
                }

                else
                {
                    model.Message = "Please create atleast one tag.";
                    model.MessageClass = "danger";
                    result.Message = model.Message;
                    result.Success = false;
                    return result;
                }
                await _db.SaveChangesAsync();

                model.Message = $"Your Post was successfully saved. You'll see it live within few minutes! Thanks for your patience!";
                model.MessageClass = "success";
                _logger.LogInformation($"New Post Published by {_user.User.FirstName} {_user.User.LastName}");
                result.Message = model.Message;
                result.Success = true;
                result.Slug = _posts.slug;
                result.ModelId = _posts.Id;
                return result;              
            }
            catch (Exception ex)
            {
                model.Message = "Some error occurred. Please try again.";
                model.MessageClass = "danger";
                _logger.LogInformation("", ex, "Error while saving Posts.");
                result.Message = model.Message;
                result.Success = false;
                return result;
            }            
        }

        public async Task<ResultsModel> Edit(Guid? id, PostsInputModel model)
        {
            ResultsModel result = new ResultsModel();
            try
            {
                var _posts = await _db.Posts.Where(a => a.Id == model.id).SingleOrDefaultAsync();

                var checkPost = await _db.Posts.Where(a => a.slug.Equals(new slugGenerator().GenerateSlug(model.Title)) && a.Id != _posts.Id).SingleOrDefaultAsync();
                if (checkPost != null)
                {
                    model.Message = "Post with same title already exists. Please create another.";
                    model.MessageClass = "danger";
                    result.Message = model.Message;
                    result.Success = false;
                    return result;
                }

                _posts.CommentStatus = model.CommentStatus == true ? CommentStatus.Allowed : CommentStatus.Blocked;
                _posts.Excerpt = model.Excerpt == null ? null : model.Excerpt.Trim();

                if (model.FeaturedImage != null)
                    _posts.FeaturedImage = SaveImage(model.FeaturedImage);

                _posts.PostContent = model.Description;
                _posts.ModifiedOn = DateTime.Now;
                _posts.PostTitle = model.Title;
                _posts.slug = new slugGenerator().GenerateSlug(model.Title.Trim());
                _posts.Status = model.PostStatus == "Publish" ? PostStatus.Published : PostStatus.Draft;

                if (model.Category != null)
                {
                    var cid = Guid.Parse(model.Category);
                    var _PCat = _db.Categories.Where(a => a.Id == cid).FirstOrDefault();     
                    _posts.Category = _PCat;
                }

                var PostsTagsRelations = _db.TagsPostsRelations.Where(a => a.Posts.Id == model.id).ToList();
                if (PostsTagsRelations.Count>0)
                {
                    _db.TagsPostsRelations.RemoveRange(PostsTagsRelations);
                    //var _ptags = _db.Posts.Include(a => a.TagsPostsRelations);
                    //foreach(var item in _ptags)
                    //{
                        
                    //}
                    _db.SaveChanges();
                }
                //var _ListTags = new List<Data.Tags>();

                if (!string.IsNullOrEmpty(model.Tags))
                {
                    var tags = model.Tags.Split(",");
                    foreach (var tag in tags)
                    {
                        var checkTags = _db.Tags.Where(a => a.slug.ToLower().Equals(new slugGenerator().GenerateSlug(tag))).FirstOrDefault();
                        if (checkTags != null)
                        {
                            var tagPostsRelation = new TagsPostsRelations()
                            {
                                Id = Guid.NewGuid(),
                                Posts = _posts,
                                Tags = checkTags
                            };
                            _db.TagsPostsRelations.Add(tagPostsRelation);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            checkTags = new Tags
                            {
                                Id = Guid.NewGuid(),
                                Name = tag.ToLower().Trim(),
                                slug = new slugGenerator().GenerateSlug(tag)
                            };

                            _db.Tags.Add(checkTags);
                            //_ListTags.Add(checkTags);

                            var tagPostsRelation = new TagsPostsRelations()
                            {
                                Id = Guid.NewGuid(),
                                Posts = _posts,
                                Tags = checkTags
                            };
                            _db.TagsPostsRelations.Add(tagPostsRelation);
                            await _db.SaveChangesAsync();
                        }

                    }
                }

                else
                {
                    model.Message = "Please create atleast one tag.";
                    model.MessageClass = "danger";
                    result.Message = model.Message;
                    result.Success = false;
                    return result;
                }
                await _db.SaveChangesAsync();
                _logger.LogInformation($"Post {_posts.PostTitle} was modified by {_user.User.FirstName} {_user.User.LastName}");

                model.Message = $"Your Post was successfully saved. You'll see it live within few minutes! Thanks for your patience!";
                model.MessageClass = "success";
                _logger.LogInformation($"New Post Published by {_user.User.FirstName} {_user.User.LastName}");
                result.Message = model.Message;
                result.Success = true;
                result.ModelId = _posts.Id;
                result.Slug = _posts.slug;
                return result;
            }
            catch (Exception ex)
            {
                model.Message = "Some error occurred while saving your Post. Please try again later.";
                model.MessageClass = "danger";
                result.Message = model.Message;
                result.Success = false;
                return result;
            }
        }

        private string SaveImage(IFormFile featuredImage)
        {
            string fileName = "";
            string folderName = "Uploads";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (featuredImage.Length > 0)
            {
                var filePath = Path.Combine(webRootPath, folderName, featuredImage.FileName);
                fileName = featuredImage.FileName;
                using (var stream = System.IO.File.Create(filePath))
                {
                    featuredImage.CopyTo(stream);
                }
            }

            return fileName;
        }

        public async Task<ResultsModel> Delete(Guid id)
        {
            try
            {
                var checkPost = await _db.Posts.Where(a => a.Id == id).SingleOrDefaultAsync();
                if (checkPost == null)
                {
                    return new ResultsModel
                    {
                        Message = "No posts were found with this ID",
                        ModelId = id,
                        Success = false
                    };
                }
                var tagPosts = _db.TagsPostsRelations.Where(a => a.Posts.Id == checkPost.Id).ToList();
                if (tagPosts.Count > 0)
                {
                    _db.TagsPostsRelations.RemoveRange(tagPosts);
                }                
                var bookmarks = _db.Bookmarks.Where(a => a.Posts.Id == checkPost.Id).SingleOrDefault();
                if (bookmarks != null)
                {
                    _db.Bookmarks.Remove(bookmarks);

                }
                _db.Posts.Remove(checkPost);
                await _db.SaveChangesAsync();
                return new ResultsModel
                {
                    Message = "Your post was removed.",
                    ModelId = id,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResultsModel
                {
                    Message = "No post were found with this ID",
                    ModelId = id,
                    Success = false,
                    Exception = ex
                };
            }
          
        }


        private CategoryViewModel GetPostCategory(Category category)
        {
            var cats = new CategoryViewModel
            {
                Id = category.Id,
                Image = category.Image,
                Name = category.Title,
                slug = category.slug
            };
            return cats;
        }

        public async Task<IList<PostsViewModel>> Get()
        {
            try
            {
                var posts = await _db.Posts.Include(a => a.Category).Include(a => a.Author).ThenInclude(a => a.SocialProfiles).
                    Where(a => a.isVerified && a.Status == PostStatus.Published && !a.Category.Title.Equals("Quotation")).
                    OrderByDescending(a=>a.PostDate).
                    ToListAsync();
                IList<PostsViewModel> model = new List<PostsViewModel>();
                foreach (var item in posts)
                {
                    model.Add(new PostsViewModel
                    {
                        Author = item.Author,
                        CommentCount = item.CommentCount,
                        CommentStatus = item.CommentStatus,
                        Excerpt = item.Excerpt,
                        FeaturedImage = item.FeaturedImage,
                        Id = item.Id,
                        ModifiedOn = item.ModifiedOn,
                        PostContent = item.PostContent,
                        PostDate = item.PostDate,
                        PostTitle = item.PostTitle,
                        slug = item.slug,
                        Status = item.Status,                      
                        isVerified = item.isVerified,
                        ViewsCount = item.ViewsCount,
                        Category = GetPostCategory(item.Category),
                        Tags = await GetPostTags(item.Id)
                    });
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public async Task<PostsViewModel> Get(string slug, string category)
        {
            var posts = new Posts(); 
            if (category != null)
            {
                posts = await _db.Posts.Include(a => a.Author).ThenInclude(a => a.SocialProfiles).Include(a => a.Category).
                Where(a => a.Category.slug.Equals(category) && a.slug.ToLower().Trim().Equals(slug.ToLower().Trim())).FirstOrDefaultAsync();
                if(posts == null)
                {
                    return null;
                }
                else
                {
                    var _dbPosts = new PostsViewModel
                    {
                        Author = posts.Author,
                        CommentCount = posts.CommentCount,
                        CommentStatus = posts.CommentStatus,
                        Excerpt = posts.Excerpt,
                        FeaturedImage = posts.FeaturedImage,
                        Id = posts.Id,
                        ModifiedOn = posts.ModifiedOn,
                        PostContent = posts.PostContent,
                        PostDate = posts.PostDate,
                        PostTitle = posts.PostTitle,
                        slug = posts.slug,
                        Status = posts.Status,
                        Category = GetPostCategory(posts.Category),
                        Tags = await GetPostTags(posts.Id),
                        isVerified = posts.isVerified,
                        ViewsCount = posts.ViewsCount
                    };
                    posts.ViewsCount = posts.ViewsCount + 1;
                    await _db.SaveChangesAsync();
                    return _dbPosts;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<PostsViewModel> Get(string slug) //Edit use
        {
            var posts = await _db.Posts.Include(a => a.Author).ThenInclude(a => a.SocialProfiles).Include(a => a.Category).
            Where(a => a.slug.ToLower().Trim().Equals(slug.ToLower().Trim())).FirstOrDefaultAsync();
            if (posts == null)
            {
                return null;
            }
            else
            {
                var _dbPosts = new PostsViewModel
                {
                    Author = posts.Author,
                    CommentCount = posts.CommentCount,
                    CommentStatus = posts.CommentStatus,
                    Excerpt = posts.Excerpt,
                    FeaturedImage = posts.FeaturedImage,
                    Id = posts.Id,
                    ModifiedOn = posts.ModifiedOn,
                    PostContent = posts.PostContent,
                    PostDate = posts.PostDate,
                    PostTitle = posts.PostTitle,
                    slug = posts.slug,
                    Status = posts.Status,
                    Category = GetPostCategory(posts.Category),
                    Tags = await GetPostTags(posts.Id),
                    isVerified = posts.isVerified,
                    ViewsCount = posts.ViewsCount
                };
                posts.ViewsCount = posts.ViewsCount + 1;
                await _db.SaveChangesAsync();
                return _dbPosts;
            }

        }

        public async Task<IList<PostsViewModel>> RelatedPosts(Guid id, Guid PostId)
        {
            IList<PostsViewModel> model = new List<PostsViewModel>();
            try
            {
                if (id != null)
                {
                    var _relatedPosts = await _db.Categories.Where(a => a.Id == id).Include(a => 
                    a.Posts).ToListAsync();
                    if (_relatedPosts.Count > 1)
                    {
                        foreach (var item in _relatedPosts)
                        {
                            foreach(var post in item.Posts.
                                Where(a=>a.isVerified && a.Status == PostStatus.Published && !a.Category.Title.Equals("Quotation") && a.Id != PostId))
                            {
                                model.Add(new PostsViewModel
                                {
                                    Author = post.Author,
                                    CommentCount = post.CommentCount,
                                    CommentStatus = post.CommentStatus,
                                    Excerpt = post.Excerpt,
                                    FeaturedImage = post.FeaturedImage,
                                    Id = post.Id,
                                    ModifiedOn = post.ModifiedOn,
                                    PostContent = post.PostContent,
                                    PostDate = post.PostDate,
                                    PostTitle = post.PostTitle,
                                    slug = post.slug,
                                    Status = post.Status,
                                    Category = GetPostCategory(post.Category),
                                    Tags = await GetPostTags(post.Id),
                                    isVerified = post.isVerified,
                                    ViewsCount = post.ViewsCount
                                });
                            }
                           
                        }
                        return model;
                    }
                    else
                    {
                        model = await GetRelatedPosts(PostId);
                        return model;
                    }
                }
                else
                {
                    model = await GetRelatedPosts(PostId);
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<IList<PostsViewModel>> GetRelatedPosts(Guid PostId)
        {
            try
            {
                IList<PostsViewModel> model = new List<PostsViewModel>();
                var _relatedPosts = await _db.Posts.Include(a => a.Author).ThenInclude(a => a.SocialProfiles).Include(a => a.Category).
                    Where(a=>a.isVerified && a.Status == PostStatus.Published && !a.Category.Title.Equals("Quotation") && a.Id!= PostId).
                    ToListAsync();
                if (_relatedPosts.Count > 1)
                {
                    foreach (var item in _relatedPosts)
                    {
                        model.Add(new PostsViewModel
                        {
                            Author = item.Author,
                            CommentCount = item.CommentCount,
                            CommentStatus = item.CommentStatus,
                            Excerpt = item.Excerpt,
                            FeaturedImage = item.FeaturedImage,
                            Id = item.Id,
                            ModifiedOn = item.ModifiedOn,
                            PostContent = item.PostContent,
                            PostDate = item.PostDate,
                            PostTitle = item.PostTitle,
                            slug = item.slug,
                            Status = item.Status,
                            Category = GetPostCategory(item.Category),
                            Tags = await GetPostTags(item.Id),
                            isVerified = item.isVerified,
                            ViewsCount = item.ViewsCount
                        });
                    }
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<NextPreviousPostsModel> NextPreviousPost(Guid PostId)
        {
            try
            {
                var PostsLists = await _db.Posts.Include(a => a.Author).ThenInclude(a => a.SocialProfiles).Include(a => a.Category).
                    Where(a => a.isVerified && a.Status == PostStatus.Published && !a.Category.Title.Equals("Quotation"))
                    .OrderByDescending(a => a.PostDate).ToListAsync();
                var prevId = new Guid();
                var nextId = new Guid();

                for (int i = 0; i < PostsLists.Count; i++)
                {
                    if (PostId == PostsLists[i].Id)
                    {
                        if (i >= 1)
                            prevId = PostsLists[i - 1].Id;
                        if ((i + 1) < PostsLists.Count)
                            nextId = PostsLists[i + 1].Id;
                        break;
                    }
                }
                NextPreviousPostsModel npModel = new NextPreviousPostsModel();
                if (prevId != null)
                {
                    var _posts = PostsLists.Where(a => a.Id == prevId).FirstOrDefault();
                    var _p =  new PostsViewModel
                    {
                        Author = _posts.Author,
                        CommentCount = _posts.CommentCount,
                        CommentStatus = _posts.CommentStatus,
                        Excerpt = _posts.Excerpt,
                        FeaturedImage = _posts.FeaturedImage,
                        Id = _posts.Id,
                        ModifiedOn = _posts.ModifiedOn,
                        PostContent = _posts.PostContent,
                        PostDate = _posts.PostDate,
                        PostTitle = _posts.PostTitle,
                        slug = _posts.slug,
                        Status = _posts.Status,
                        Category = GetPostCategory(_posts.Category),
                        Tags = await GetPostTags(_posts.Id),
                        isVerified = _posts.isVerified,
                        ViewsCount = _posts.ViewsCount
                    };
                    npModel.PreviousPost = _p;
                }
                if (nextId != null)
                {
                    var _posts = PostsLists.Where(a => a.Id == nextId).FirstOrDefault();
                    var _n = new PostsViewModel
                    {
                        Author = _posts.Author,
                        CommentCount = _posts.CommentCount,
                        CommentStatus = _posts.CommentStatus,
                        Excerpt = _posts.Excerpt,
                        FeaturedImage = _posts.FeaturedImage,
                        Id = _posts.Id,
                        ModifiedOn = _posts.ModifiedOn,
                        PostContent = _posts.PostContent,
                        PostDate = _posts.PostDate,
                        PostTitle = _posts.PostTitle,
                        slug = _posts.slug,
                        Status = _posts.Status,
                        Category = GetPostCategory(_posts.Category),
                        Tags = await GetPostTags(_posts.Id),
                        isVerified = _posts.isVerified,
                        ViewsCount = _posts.ViewsCount
                    };
                    npModel.NextPost = _n;
                }

                return npModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<TagsInput>> GetPostTags(Guid PostId)
        {
            var _tags = await _db.TagsPostsRelations.Where(a => a.Posts.Id == PostId).Include(a => a.Tags).ToListAsync();
            IList<TagsInput> tags = new List<TagsInput>();
            foreach (var tag in _tags)
            {
                tags.Add(new TagsInput
                {
                    Id = tag.Id,
                    Name = tag.Tags.Name,
                    Slug = tag.Tags.Name
                });
            }

            return tags;
        }
        public IList<TagsInput> GetPostsTags(Guid PostId)
        {
            var _tags = _db.TagsPostsRelations.Where(a => a.Posts.Id == PostId).Include(a => a.Tags).ToList();
            IList<TagsInput> tags = new List<TagsInput>();
            foreach (var tag in _tags)
            {
                tags.Add(new TagsInput
                {
                    Id = tag.Id,
                    Name = tag.Tags.Name,
                    Slug = tag.Tags.Name
                });
            }

            return tags;
        }

        public async Task<BookmarkStatus> Bookmark(string slug)
        {
            try
            {
                var SModel = await _db.Posts.Where(a => a.slug == slug).FirstOrDefaultAsync();              
                var checkModel = await _db.Bookmarks.Where(a => a.Posts.Id == SModel.Id).SingleOrDefaultAsync();
                
                if (checkModel == null)
                {
                    Bookmarks myBookmarks = new Bookmarks
                    {
                        Posts = SModel,
                        Id = Guid.NewGuid(),
                        Users = _user.User,
                        AddedOn = DateTime.Now,
                        BookmarkType = BookmarkType.Posts
                    };
                    _db.Bookmarks.Add(myBookmarks);
                    await _db.SaveChangesAsync();

                    return BookmarkStatus.Added;
                }
                else
                {
                    return BookmarkStatus.AlreadyExists;
                }
            }
            catch (Exception ex)
            {
                return BookmarkStatus.AlreadyExists;
            }
        }

        public async Task<IList<CategoryViewModel>> AllCategories()
        {
            try
            {
                var model = await _db.Categories.Include(a=>a.Posts).Include(a=>a.CreatedBy).ToListAsync();
                var CategoryLists = new List<CategoryViewModel>();
                foreach(var item in model)
                {
                    CategoryLists.Add(new CategoryViewModel
                    {
                        Id = item.Id,
                        Name = item.Title,
                        slug = item.slug,
                        Image = item.Image,
                        Posts = await GetCategoryPostsAsync(item)
                    });
                }
          
                return CategoryLists;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IList<CategoryViewModel> Categories
        {
            get
            {
                try
                {
                    var model = _db.Categories.Include(a => a.Posts).Include(a => a.CreatedBy).ToList();
                    var CategoryLists = new List<CategoryViewModel>();
                    foreach (var item in model)
                    {
                        CategoryLists.Add(new CategoryViewModel
                        {
                            Id = item.Id,
                            Name = item.Title,
                            slug = item.slug,
                            Image = item.Image,
                            Posts = GetPostsByCategory(item)
                        });
                    }

                    return CategoryLists;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
           
        }

        private IList<PostsViewModel> GetPostsByCategory(Category cat)
        {
            var postLists = new List<PostsViewModel>();
            foreach (var item in cat.Posts.Where(a => a.isVerified && a.Status == PostStatus.Published && !a.Category.Title.Equals("Quotation")))
            {
                postLists.Add(new PostsViewModel
                {
                    Author = item.Author,
                    CommentCount = item.CommentCount,
                    CommentStatus = item.CommentStatus,
                    Excerpt = item.Excerpt,
                    FeaturedImage = item.FeaturedImage,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn,
                    PostContent = item.PostContent,
                    PostDate = item.PostDate,
                    PostTitle = item.PostTitle,
                    slug = item.slug,
                    Status = item.Status,
                    Category = GetPostCategory(item.Category),
                    Tags = GetPostsTags(item.Id),
                    isVerified = item.isVerified,
                    ViewsCount = item.ViewsCount
                });
            }
            return postLists;
        }

        public async Task<IList<PostsViewModel>> GetCategoryPostsAsync(Category cat)
        {
            var postLists = new List<PostsViewModel>();
            foreach(var item in cat.Posts.Where(a => a.isVerified && a.Status == PostStatus.Published && !a.Category.Title.Equals("Quotation")))
            {
                postLists.Add(new PostsViewModel
                {
                    Author = item.Author,
                    CommentCount = item.CommentCount,
                    CommentStatus = item.CommentStatus,
                    Excerpt = item.Excerpt,
                    FeaturedImage = item.FeaturedImage,
                    Id = item.Id,
                    ModifiedOn = item.ModifiedOn,
                    PostContent = item.PostContent,
                    PostDate = item.PostDate,
                    PostTitle = item.PostTitle,
                    slug = item.slug,
                    Status = item.Status,
                    Category = GetPostCategory(item.Category),
                    Tags = await GetPostTags(item.Id),
                    isVerified = item.isVerified,
                    ViewsCount = item.ViewsCount
                });
            }
            return postLists;
        }
        public async Task<IList<PostsViewModel>> GetCategoryPosts(string cat)
        {
            try
            {
                var category = await _db.Categories.Where(a => a.slug.Equals(cat)).Include(a => a.Posts).SingleOrDefaultAsync();
                var postLists = new List<PostsViewModel>();
                foreach (var item in category.Posts.Where(a => a.isVerified && a.Status == PostStatus.Published))
                {
                    postLists.Add(new PostsViewModel
                    {
                        Author = await GetPostsAuthor(item), //item.Author,
                        CommentCount = item.CommentCount,
                        CommentStatus = item.CommentStatus,
                        Excerpt = item.Excerpt,
                        FeaturedImage = item.FeaturedImage,
                        Id = item.Id,
                        ModifiedOn = item.ModifiedOn,
                        PostContent = item.PostContent,
                        PostDate = item.PostDate,
                        PostTitle = item.PostTitle,
                        slug = item.slug,
                        Status = item.Status,
                        Category = GetPostCategory(item.Category),
                        Tags = await GetPostTags(item.Id),
                        isVerified = item.isVerified,
                        ViewsCount = item.ViewsCount
                    });
                }
                return postLists;
            }
            catch (Exception ex)
            {
                return null;
            }           
        }

        public async Task<IList<PostsViewModel>> GetTagPosts(string slug)
        {
            try
            {
                var tags = await _db.Tags.Where(a => a.slug.Equals(slug)).Include(a => a.TagsPostsRelations).ToListAsync();
                var postLists = new List<PostsViewModel>();
                foreach (var tag in tags)
                {
                    foreach(var item in tag.TagsPostsRelations)
                    {
                        postLists.Add(new PostsViewModel
                        {
                            Author = item.Posts.Author,
                            CommentCount = item.Posts.CommentCount,
                            CommentStatus = item.Posts.CommentStatus,
                            Excerpt = item.Posts.Excerpt,
                            FeaturedImage = item.Posts.FeaturedImage,
                            Id = item.Posts.Id,
                            ModifiedOn = item.Posts.ModifiedOn,
                            PostContent = item.Posts.PostContent,
                            PostDate = item.Posts.PostDate,
                            PostTitle = item.Posts.PostTitle,
                            slug = item.Posts.slug,
                            Status = item.Posts.Status,
                            Category = GetPostCategory(item.Posts.Category),
                            Tags = await GetPostTags(item.Posts.Id),
                            isVerified = item.Posts.isVerified,
                            ViewsCount = item.Posts.ViewsCount
                        });
                    }

                   
                }
                return postLists;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<PostsViewModel>> GetPostsByAuthor(string username)
        {
            try
            {
                var _posts = await _db.Posts.Include(a=>a.Category).Include(a=>a.Author).Where(a => a.Author.UserName.Equals(username) && a.Status == PostStatus.Published && a.isVerified).ToListAsync();
                var postLists = new List<PostsViewModel>();
                foreach (var item in _posts)
                {
                    postLists.Add(new PostsViewModel
                    {
                        Author = item.Author,
                        CommentCount = item.CommentCount,
                        CommentStatus = item.CommentStatus,
                        Excerpt = item.Excerpt,
                        FeaturedImage = item.FeaturedImage,
                        Id = item.Id,
                        ModifiedOn = item.ModifiedOn,
                        PostContent = item.PostContent,
                        PostDate = item.PostDate,
                        PostTitle = item.PostTitle,
                        slug = item.slug,
                        Status = item.Status,
                        Category = GetPostCategory(item.Category),
                        Tags = await GetPostTags(item.Id),
                        isVerified = item.isVerified,
                        ViewsCount = item.ViewsCount
                    });

                }
                return postLists;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<PostsViewModel>> MyStories(AppUsers user)
        {
            try
            {
                var _posts = await _db.Bookmarks.Include(a=>a.Users).Include(a => a.Posts).ThenInclude(a=>a.Category).Where(a => a.Users.Id == user.Id).ToListAsync();
                var postLists = new List<PostsViewModel>();
                foreach (var item in _posts)
                {
                    postLists.Add(new PostsViewModel
                    {
                        Author = await GetPostsAuthor(item.Posts),
                        CommentCount = item.Posts.CommentCount,
                        CommentStatus = item.Posts.CommentStatus,
                        Excerpt = item.Posts.Excerpt,
                        FeaturedImage = item.Posts.FeaturedImage,
                        Id = item.Posts.Id,
                        ModifiedOn = item.Posts.ModifiedOn,
                        PostContent = item.Posts.PostContent,
                        PostDate = item.Posts.PostDate,
                        PostTitle = item.Posts.PostTitle,
                        slug = item.Posts.slug,
                        Status = item.Posts.Status,
                        Category = GetPostCategory(item.Posts.Category),
                        Tags = await GetPostTags(item.Posts.Id),
                        isVerified = item.Posts.isVerified,
                        ViewsCount = item.Posts.ViewsCount
                    });

                }
                return postLists;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<PostsViewModel>> MyStories(AppUsers user, PostStatus postStatus)
        {
            try
            {
                var _posts = await _db.Posts.Include(a=>a.Author).Include(a=>a.Category).Where(a => a.Author.Id == user.Id && a.Status == postStatus).ToListAsync();
                var postLists = new List<PostsViewModel>();
                foreach (var item in _posts)
                {
                    postLists.Add(new PostsViewModel
                    {
                        Author = await GetPostsAuthor(item),
                        CommentCount = item.CommentCount,
                        CommentStatus = item.CommentStatus,
                        Excerpt = item.Excerpt,
                        FeaturedImage = item.FeaturedImage,
                        Id = item.Id,
                        ModifiedOn = item.ModifiedOn,
                        PostContent = item.PostContent,
                        PostDate = item.PostDate,
                        PostTitle = item.PostTitle,
                        slug = item.slug,
                        Status = item.Status,
                        Category = GetPostCategory(item.Category),
                        Tags = await GetPostTags(item.Id),
                        isVerified = item.isVerified,
                        ViewsCount = item.ViewsCount
                    });

                }
                return postLists;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<PostsViewModel>> Search(string q, int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (!string.IsNullOrEmpty(q) || !string.IsNullOrWhiteSpace(q))
            {
                var searchText = q.ToLower();
                var _posts = await _db.Posts.Include(a => a.Author).ThenInclude(a => a.SocialProfiles).Include(a => a.Category).
                    Where(a => (a.Excerpt.ToLower().Contains(searchText) ||
                a.PostContent.ToLower().Contains(searchText) ||
                a.PostTitle.ToLower().Contains(searchText) ||
                a.Category.Title.ToLower().Contains(searchText)) &&
                a.Status == PostStatus.Published && a.isVerified && !a.Category.Title.Equals("Quotation")).ToListAsync();
                var postLists = new List<PostsViewModel>();
                foreach (var item in _posts)
                {
                    postLists.Add(new PostsViewModel
                    {
                        Author = await GetPostsAuthor(item),
                        CommentCount = item.CommentCount,
                        CommentStatus = item.CommentStatus,
                        Excerpt = item.Excerpt,
                        FeaturedImage = item.FeaturedImage,
                        Id = item.Id,
                        ModifiedOn = item.ModifiedOn,
                        PostContent = item.PostContent,
                        PostDate = item.PostDate,
                        PostTitle = item.PostTitle,
                        slug = item.slug,
                        Status = item.Status,
                        Category = GetPostCategory(item.Category),
                        Tags = await GetPostTags(item.Id),
                        isVerified = item.isVerified,
                        ViewsCount = item.ViewsCount
                    });
                }
                return postLists;
            }
            else
            {
                return null;
            }
        }

        private async Task<AppUsers> GetPostsAuthor(Posts posts)
        {
            return await _db.Posts.Where(a => a.Id == posts.Id).Select(a => a.Author).SingleOrDefaultAsync();
        }

        public async Task<IList<PostsViewModel>> Quotes()
        {
            try
            {
                IList<PostsViewModel> Quotes = new List<PostsViewModel>();
                var _quotes = await _db.Posts.Include(a => a.Author).ThenInclude(a => a.SocialProfiles).Include(a => a.Category).
                    Where(a => a.isVerified && a.Status == PostStatus.Published && a.Category.Title.Equals("Quotation")).ToListAsync();
                foreach (var posts in _quotes)
                {
                    Quotes.Add(new PostsViewModel
                    {
                        Author = posts.Author,
                        CommentCount = posts.CommentCount,
                        CommentStatus = posts.CommentStatus,
                        Excerpt = posts.Excerpt,
                        FeaturedImage = posts.FeaturedImage,
                        Id = posts.Id,
                        ModifiedOn = posts.ModifiedOn,
                        PostContent = posts.PostContent,
                        PostDate = posts.PostDate,
                        PostTitle = posts.PostTitle,
                        slug = posts.slug,
                        Status = posts.Status,
                        Category = GetPostCategory(posts.Category),
                        Tags = await GetPostTags(posts.Id),
                        isVerified = posts.isVerified,
                        ViewsCount = posts.ViewsCount
                    });
                }
                return Quotes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
