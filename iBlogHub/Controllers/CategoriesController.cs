using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Data;
using iBlogHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace iBlogHub.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly IPostsService _postService;
        private readonly ApplicationDbContext _db;
        public CategoriesController(IPostsService postsService, ApplicationDbContext db): base(db, postsService)
        {
            _postService = postsService;
            _db = db;
        }

        [Route("Categories/")]
        public async Task<IActionResult> Index()
        {
            
            var model = await _postService.AllCategories();
            return View(model);
        }

        [HttpGet]
        [Route("/{slug}/Posts")]
        public async Task<IActionResult> Posts(string slug)
        {
            
            var cat = _db.Categories.Where(a => a.slug == slug).SingleOrDefault();
            ViewBag.Category = cat;
            var model = await _postService.GetCategoryPosts(slug);
            if(model == null)
            {
                return View(new List<PostsViewModel>());
            }
            if(slug.ToLower().Equals("quotation"))
            {
                return RedirectToAction("Quotes", "Stories");
            }
            else
            {
                return View(model);
            }
            
        }
    }
}