using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using iBlogHub.Helpers;
using iBlogHub.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iBlogHub.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IPostsService _postService;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICurrentUser _cUser;
        private AppUsers _users;
        public ProfileController(IPostsService postsService,
            ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment,
            ICurrentUser cuser):base(context, postsService)
        {
            _postService = postsService;
            _db = context;
            _hostingEnvironment = hostingEnvironment;
            _cUser = cuser;
        }
        
        [Route("/author/{username}")]
        public async Task<IActionResult> Index(string username="")
        {
            if(username == "")
            {
                return NotFound();
            }
            _users = _db.AppUsers.Where(a => a.UserName == username).Include(a=>a.SocialProfiles).FirstOrDefault();
            var model = await _postService.GetPostsByAuthor(username);
            if (model == null)
            {
                return View(new List<PostsViewModel>());
            }
            ViewData["ProfileUser"] = _users;
            
            return View(model);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Change Pic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePic(IFormFile Photo)
        {
            string fileName = "";
            string folderName = "Uploads";
            string webRootPath = _hostingEnvironment.WebRootPath;
            bool success = false;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (Photo.Length > 0)
            {
                var filePath = Path.Combine(webRootPath, folderName, Photo.FileName);
                fileName = Photo.FileName;
                using (var stream = System.IO.File.Create(filePath))
                {
                    Photo.CopyTo(stream); 
                }

                var _dbUser = await _db.AppUsers.Where(a => a.Id == _cUser.User.Id).FirstOrDefaultAsync();
                _dbUser.Photo = fileName;
                _dbUser.PhotoPath = "Uploads";
                await _db.SaveChangesAsync();
                success = true;
            }
            return Json(new { error = success, msg = "Your Profile has been updated." });
        }
    }
}