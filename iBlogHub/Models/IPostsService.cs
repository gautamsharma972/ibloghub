using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Models
{
    public interface IPostsService
    {
        /// <summary>
        /// Add new Post Service, Parameter type - PostsInputModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ResultsModel</returns>
        public Task<ResultsModel> Create(PostsInputModel model);

        /// <summary>
        /// Edit Post, Parameter Type - PostsInputModel
        /// </summary>
        /// <returns>ResultsModel</returns>        
        public Task<ResultsModel> Edit(Guid? id, PostsInputModel model);

        /// <summary>
        /// Returns the lists of posts
        /// </summary>
        /// <returns>List<PostsViewModel></returns>
        public Task<IList<PostsViewModel>> Get();

        /// <summary>
        /// Get a post matching slug AND Category
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>List<PostsViewModel></returns>
        public Task<PostsViewModel> Get(string slug, string category="");

        /// <summary>
        /// Get a post matching slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>List<PostsViewModel></returns>
        public Task<PostsViewModel> Get(string slug);

        /// <summary>
        /// Get Related Posts matching category Id
        /// </summary>
        /// <param name="CatId, PostId"></param>
        /// <returns>List<PostsViewModel></returns>
        public Task<IList<PostsViewModel>> RelatedPosts(Guid CatId, Guid PostId);

        /// <summary>
        /// Get Next - Previous Posts scroller 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NextPreviousPostsModel</returns>
        public Task<NextPreviousPostsModel> NextPreviousPost(Guid PostId);

        /// <summary>
        /// Create Bookmark of a Post or Highlighted texts
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>Added?AlreadyExists</returns>
        public Task<BookmarkStatus> Bookmark(string slug);

        /// <summary>
        /// Deletes the Post with given GUID Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResultsModel</returns>
        public Task<ResultsModel> Delete(Guid id);

        /// <summary>
        /// Returns all categories from the database
        /// </summary>
        /// <returns>Lists of Categories including the Posts</returns>
        public Task<IList<CategoryViewModel>> AllCategories();

        /// <summary>
        /// Gets all Posts from the database matching category
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>Lists of Posts</returns>
        public Task<IList<PostsViewModel>> GetCategoryPosts(string slug);

        /// <summary>
        /// Gets all the Posts from the database matching given tag
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>Lists of posts</returns>
        public Task<IList<PostsViewModel>> GetTagPosts(string slug);

        /// <summary>
        /// Gets all the Posts from the database by Authors
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Lists of Posts</returns>
        public Task<IList<PostsViewModel>> GetPostsByAuthor(string username);

        /// <summary>
        /// Get all the tags of a Posts mathces the Id
        /// </summary>
        /// <param name="PostsId"></param>
        /// <returns>List of tags</returns>
        public Task<IList<TagsInput>> GetPostTags(Guid PostsId);

        /// <summary>
        /// Gets all the featured posts
        /// </summary>
        /// <returns>Lists of Posts</returns>
        public IList<PostsViewModel> FeaturedPosts { get; }

        /// <summary>
        /// Gets all the bookmarks of a user loggedin
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lists of Posts</returns>
        public Task<IList<PostsViewModel>> MyStories(AppUsers user);

        /// <summary>
        /// Gets all the Posts published and drafts by the user logged in
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lists of Posts</returns>
        public Task<IList<PostsViewModel>> MyStories(AppUsers user, PostStatus postStatus);

        /// <summary>
        /// Search for Posts
        /// </summary>
        /// <param name="q"></param>
        /// <param name="page"></param>
        /// <returns>Single or list of posts matching search query</returns>
        public Task<IList<PostsViewModel>> Search(string q, int? page);

        /// <summary>
        /// Get all the Quotes from the Database
        /// </summary>
        /// <returns>List of Quotes</returns>
        public Task<IList<PostsViewModel>> Quotes();

        public IList<CategoryViewModel> Categories { get; }


        public IList<TagsInput> Tags { get; }
    }
}
