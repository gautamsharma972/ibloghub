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
    public class MyStoriesModel : PageModel
    {
        private readonly IPostsService _postService;
        private readonly ICurrentUser _cUser;

        public MyStoriesModel(
           IPostsService postsService,
            ICurrentUser cuser)
        {
            _postService = postsService;
            _cUser = cuser;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public IList<PostsViewModel> Posts { get; set; }
        public async Task OnGetAsync()
        {
            Posts = await _postService.MyStories(_cUser.User, Enums.PostStatus.Published);
        }
    }
}
