using iBlogHub.Data;
using iBlogHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext _context;
        private IPostsService _postService;
        public BaseController(ApplicationDbContext context, IPostsService postsService)
        {
            _context = context;
            _postService = postsService;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            GetMetaData();
            base.OnActionExecuted(context);
        }
        public void GetMetaData()
        {
            ViewData["Newsletter"] = new Newsletters();             
        }


    }
}