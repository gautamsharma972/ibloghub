using AutoMapper;
using iBlogHub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace iBlogHub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var _articles = _db.Posts.Include(a => a.Author).Include(a => a.Category).ToList();
            //var articleModel = Mapper.Map<List<ArticlesModel>>(_articles);
            //foreach (var item in articleModel)
            //{
            //    item.User = _db.Users.Where(a => a.Id == item.User_Id).FirstOrDefault();
            //}
            //var uid = User.Identity.GetUserId();
            //AdminModel model = new AdminModel
            //{
            //    Articles = articleModel,
            //    Categories = Mapper.Map<List<CategoriesModel>>(_db.Categories.ToList()),
            //    Notifications = _db.Notifications.ToList(),
            //    Tags = Mapper.Map<List<TagsModel>>(_db.Tags.ToList()),
            //    Users = _db.Users.ToList(),
            //    CurrentUser = _db.Users.Where(a => a.Id == uid).SingleOrDefault()
            //};
            return View(_articles);
        }

        [HttpPost]
        public async Task<IActionResult> Verify(Guid id)
        {
            var _posts = await _db.Posts.Where(a => a.Id == id).FirstOrDefaultAsync();
            _posts.isVerified = true;
            await _db.SaveChangesAsync();
            return Json(new { msg = "successfully verified" });
        }

        //[HttpPost]
        //public ActionResult VerifyPost(Guid id)
        //{
        //    bool result = false;
        //    if(id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var obj = _db.Articles.Where(a => a.Id == id).SingleOrDefault();
        //    obj.isVerified = true;
        //    _db.SaveChanges();
        //    result = true;
        //    return Json(new { result = result, msg = result ? "Saved" : "Error occurred", id = id }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult VerifyCategory(Guid id)
        //{
        //    bool result = false;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var obj = _db.Categories.Where(a => a.Id == id).SingleOrDefault();
        //    obj.isRequest = false;
        //    _db.SaveChanges();
        //    result = true;
        //    return Json(new { result = result, msg = result ? "Saved" : "Error occurred", id = id }, JsonRequestBehavior.AllowGet);
        //}
    }
}