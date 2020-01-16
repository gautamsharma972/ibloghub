using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using iBlogHub.Helpers;
using iBlogHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace iBlogHub.Areas.Identity.Pages.Account.Manage
{
    public partial class BookmarksModel : PageModel
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly IPostsService _postService;
        private readonly ICurrentUser _cUser;

        public BookmarksModel(
           UserManager<AppUsers> userManager,
           SignInManager<AppUsers> signInManager,
           ApplicationDbContext db, IPostsService postsService,
            ICurrentUser cuser)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
            _postService = postsService;
            _cUser = cuser;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public IList<PostsViewModel> Posts { get; set; }
        public async Task OnGetAsync()
        {
            Posts = await _postService.MyStories(_cUser.User);            
        }
    }
}
