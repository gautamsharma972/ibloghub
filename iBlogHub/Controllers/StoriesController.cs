using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using iBlogHub.Data;
using iBlogHub.Helpers;
using iBlogHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PagedList.Core;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Controllers
{

    public class StoriesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IPostsService _postsService;
        private readonly ICurrentUser _user;
        private readonly ILogger<PostsInputModel> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public StoriesController(ApplicationDbContext context,
            IPostsService postsService,
             ILogger<PostsInputModel> logger,
            ICurrentUser user, IHostingEnvironment hostingEnvironment) : base(context, postsService)
        {
            _context = context;
            _postsService = postsService;
            _user = user;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var model = await _postsService.Get();
            
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Post()
        {
            return View("_NewPost", new PostInputCategoryModel());            
        }

        [HttpPost]
        public IActionResult Post(PostInputCategoryModel model)
        {
            if (!string.IsNullOrEmpty(model.Category))
            {
                var _quotesCheck = _context.Categories.Where(a => a.Id.ToString() == model.Category).FirstOrDefault();
                if (_quotesCheck.Title.Equals("Quotation"))
                {
                    return View("QuotesCreate", new PostsInputModel { isCategorySelected = true, Category = model.Category });
                }
                else
                {
                    return View("Create", new PostsInputModel { isCategorySelected = true, Category = model.Category, SelectedCategoryName = _quotesCheck.Title });
                }                
            }
            else
            {
                return View("_NewPost", new PostInputCategoryModel());
            }
        }

        [Authorize]
        public async Task<IActionResult> Edit(string slug = "")
        {
            if (slug == "")
            {
                return Error();
            }
            var posts = await _postsService.Get(slug);
           
            if (posts == null)
            {
                ErrorViewModel error = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    ErrorType = ErrorType.Posts
                };
                return View("Error", error);
            }

            if (_user.User.Id != posts.Author.Id)
            {
                return View("Notauthorized");
            }

            var _ptags = await _postsService.GetPostTags(posts.Id);
            IList<string> Ktags = new List<string>();
            string tags = "";
            foreach (var item in _ptags)
            {
                Ktags.Add(item.Name);
            }
            tags = string.Join(",", Ktags);
            PostsInputModel model = new PostsInputModel
            {
                id = posts.Id,
                Category = GetPostCategory(posts),
                CommentStatus = posts.CommentStatus == CommentStatus.Allowed ? true : false,
                Description = posts.PostContent,
                Excerpt = posts.Excerpt,
                PostFeaturedImage = posts.FeaturedImage,
                Tags = tags,
                Title = posts.PostTitle
            };
            
            var _quotesCheck = _context.Categories.Where(a => a.Id.ToString() == model.Category).FirstOrDefault();
            var _selCategories = _postsService.Categories;
            var CategorySelectList = new List<SelectListItem>();
            foreach (var item in _selCategories)
            {
                CategorySelectList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Selected = (item.Id == _quotesCheck.Id) ? true : false,
                    Value = item.Id.ToString()
                });
            }
            ViewData["CategorySelectList"] = CategorySelectList;
            if (_quotesCheck.Title.Equals("Quotation"))
            {
                return View("QuotesEdit", model);
            }

            
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PostsInputModel model)
        {
            
            var _quotesCheck = _context.Categories.Where(a => a.Id.ToString() == model.Category).FirstOrDefault();
            if (_quotesCheck.Title.Equals("Quotation"))
            {
                if (!string.IsNullOrEmpty(model.Description))
                {
                    var content = Html2PlainText.Decode(model.Description);
                    model.Title = content.Length > 100 ? content.Substring(0, 99) : content;
                    model.Excerpt = content.Length > 255 ? content.Substring(0, 254) : content; //.Substring(0, 255);
                }
                else
                {
                    //ModelState.AddModelError("", "Please provide a valid content");
                    return View("QuotesCreate", model);
                }
            }
            if (!ModelState.IsValid)
            {
                if (_quotesCheck.Title.Equals("Quotation"))
                {
                    ModelState.AddModelError("", "Some error occurred. Please try again later.");
                    return View("QuotesEdit", model);
                }
                else
                {
                    return View("Edit", model);
                }
                
            }
            ResultsModel result = await _postsService.Edit(id, model);
            if (result.Success)
            {
                return RedirectToAction("Success", new { slug = result.Slug, edit = 1, category = _quotesCheck.Title });
            }
            else
            {
                if (_quotesCheck.Title.Equals("Quotation"))
                {
                    return View("QuotesEdit", model);
                }
                else
                {
                    return View("Edit", model);
                }
               
            }
           
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return RedirectToAction(nameof(Post));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostsInputModel model)
        {
            var _quotesCheck = _context.Categories.Where(a => a.Id.ToString() == model.Category).FirstOrDefault();
            if (_quotesCheck.Title.Equals("Quotation"))
            {
                if (!string.IsNullOrEmpty(model.Description))
                {
                    var content = Html2PlainText.Decode(model.Description);
                    model.Title = content.Length > 100 ? content.Substring(0, 99) : content;
                    model.Excerpt = content.Length > 255 ? content.Substring(0, 254) : content;                    
                }
                else
                {
                    return View("QuotesCreate", model);
                }
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    if (_quotesCheck.Title.Equals("Quotation"))
                    {
                        ModelState.AddModelError("", "Some error occurred. Please try again later.");
                        return View("QuotesCreate", model);
                    }
                    else
                    {
                        return View("Create", model);
                    }
                }
            }
           
            ResultsModel result = await _postsService.Create(model);
            if (result.Success)
            {
                return RedirectToAction("Success", new { slug = result.Slug, edit = 0, category = _quotesCheck.Title });
            }
            else
            {
                if (_quotesCheck.Title.Equals("Quotation"))
                { 
                    return View("QuotesCreate", model); 
                }
                else
                {
                    return View("Create", model);
                }                    
            }
        }

        [Authorize]
        public IActionResult Success(string slug, int? edit = 0, string category = "")
        {
            
            var Posts = _context.Posts.Where(a => a.slug.Equals(slug)).Select(a => new PostsViewModel
            {
                Id = a.Id,
                PostTitle = a.PostTitle,
                slug = a.slug,
                Status = a.Status,
                ViewCategory = category
            }).FirstOrDefault();

            if (edit == 1)
                Posts.Message = "Your Post was modified successfully.";
            else
                Posts.Message = "Your Post has been published and is pending review, you'll see it live within few minutes. Thanks!";

            if (Posts == null)
            {
                return NotFound();
            }
            else
            {
                return View(Posts);
            }
        }
        public async Task<IActionResult> RequestCategories(string Name)
        {
            try
            {
                Data.Category category = new Category();
                string _catSlug = new slugGenerator().GenerateSlug(Name);
                var _cats = _context.Categories.Where(a => a.slug == _catSlug).SingleOrDefault();
                if (_cats == null)
                {
                    category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Title = Name,
                        slug = _catSlug,
                        Status = CategoryStatus.Requested,
                        CreatedBy = _user.User
                    };
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                    return new JsonResult(new { Status = 1, Message = "Category requested", id = category.Id, name = category.Title });
                }
                else
                {
                    if (_cats.Status == CategoryStatus.Requested)
                    {
                        return new JsonResult(new { Status = 1, Message = "Category requested", id = _cats.Id, name = _cats.Title });
                    }
                    else
                    {
                        return new JsonResult(new { Status = 0, Message = "This Category already exists. Please try another.", id = _cats.Id, name = _cats.Title });
                    }
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new { Status = 0, Message = "Some error occurred while processing your request. Please try again." });
            }
        }

        private string GetPostCategory(PostsViewModel posts)
        {
            var cat = _context.Categories.Where(a => a.Id == posts.Category.Id).FirstOrDefault().Id.ToString() ?? "-1";
            return cat;
        }

        [HttpPost]
        public async Task<IActionResult> AddToBookmark(string slug)
        {
            var storiesUrl = "/Identity/Account/Manage/Bookmarks";
            if (!User.Identity.IsAuthenticated)
            {
                var loginInUrl = "/Identity/Account/Login";
                return Json(new { error = true, msg = "You need to login to add this post to your collection. Click <a href=\"" + loginInUrl + "\">here</a> to login now." });
            }
            try
            {
                var result = await _postsService.Bookmark(slug);
                if (result == BookmarkStatus.Added)
                {
                    return Json(new { error = true, msg = "Article was successfully added to your Stories collection. Click <a href=\"" + storiesUrl + "\">here</a> to check now." });
                }
                else
                {
                    return Json(new { error = true, msg = "No need, You've already added this Article to your Collection. Click <a href=\"" + storiesUrl + "\">here</a> to check now." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, msg = "No need, You've already added this Article to your Collection. Click <a href=\"" + storiesUrl + "\">here</a> to check now." });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return Json(new { error = true, msg = "Could not find any posts." });
            }
            var result = await _postsService.Delete(id);
            return Json(new { error = result.Success ? false : true, msg = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBookmark(Guid id)
        {
            try
            {
                var _userPosts = await _context.Bookmarks.Include(a => a.Posts).Where(a => a.Users.Id == _user.User.Id && a.Posts.Id == id).SingleOrDefaultAsync();
                _context.Bookmarks.Remove(_userPosts);
                await _context.SaveChangesAsync();
                return Json(new { success = true, msg = "Bookmark has been removed from your collection." });
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Some error occurred. Please try again later." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllStory()
        {
            try
            {
                var _userPosts = await _context.Bookmarks.Where(a => a.Users.Id == _user.User.Id).ToListAsync();
                _context.Bookmarks.RemoveRange(_userPosts);
                await _context.SaveChangesAsync();
                return Json(new { success = true, msg = "All bookmartks was removed from your collection" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = "Some error occurred. Please try again later." });
            }
        }

        [HttpGet]
        public IActionResult Featured()
        {
                return View();            
        }

        [HttpGet]
        [Route("/Quotes")]
        public async Task<IActionResult> Quotes()
        {
            
            try
            {
                var _quotes = await _postsService.Quotes();
                return View(_quotes);
            }
            catch (Exception ex)
            {
                return Error();
            }
        }
    }
}