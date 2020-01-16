using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace iBlogHub.Helpers
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ApplicationDbContext _context;

        private AppUsers _user;

        public CurrentUser(IHttpContextAccessor httpContext, ApplicationDbContext context)
        {
            _httpContext = httpContext;
            _context = context;
        }

        public AppUsers User
        {
            get
            {
                var currentUser = _user
                                  ?? (_user = _context.AppUsers.SingleOrDefault(a => a.UserName == _httpContext.HttpContext.User.Identity.Name));
                if (currentUser == null)
                    currentUser = new AppUsers() { UserName = "Need to Login" };
                return currentUser;
            }
        }
    }
}
