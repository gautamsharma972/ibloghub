using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBlogHub.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService _postsService;
        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [Route("/{category}/{slug}")]
        public async Task<IActionResult> Index(string category = "", string slug = "")
        {
            if (slug != "")
            {
                var _posts = await _postsService.Get(slug, category);
                try
                {
                    ViewData["MoreArticles"] = await _postsService.RelatedPosts(_posts.Category.Id, _posts.Id);
                    var _nextPrevPosts = await _postsService.NextPreviousPost(_posts.Id);
                    ViewData["PrevArticle"] = _nextPrevPosts.PreviousPost;
                    ViewData["NextArticle"] = _nextPrevPosts.NextPost;
                    ViewData["AllQuotes"] = await _postsService.Quotes();
                    if (category.ToLower().Trim().Equals("quotation"))
                    {
                        return View("Quotes", _posts);
                    }
                }
                catch (Exception)
                {

                    //throw;
                }
               
                return View(_posts);
            }
            return View("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}