using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Data;
using iBlogHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBlogHub.Controllers
{
    public class TagsController : BaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IPostsService _postService;
        public TagsController(ApplicationDbContext db, 
            IPostsService postsService): 
            base(db, postsService)
        {
            _db = db;
            _postService = postsService;
        }

        [HttpGet]
        [Route("/Tags/{slug}/Posts")]
        public async Task<IActionResult> Posts(string slug)
        {
            
            ViewBag.Tag = _db.Tags.Where(a => a.slug == slug).SingleOrDefault();
            var tagPosts = await _postService.GetTagPosts(slug);
            if(tagPosts == null)
            {
                return View(new PostsViewModel());
            }
            if (slug.ToLower().Equals("quotation"))
            {
                return RedirectToAction("Quotes", "Stories");
            }
            else
            {
                return View(tagPosts);
            }            
        }
    }
}