using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using iBlogHub.Helpers;
using iBlogHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iBlogHub.Areas.Identity.Pages.Account.Manage
{
    public partial class SocialLinksModel : PageModel
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUser _cUser;

        public SocialLinksModel(
          UserManager<AppUsers> userManager,
          SignInManager<AppUsers> signInManager,
          ApplicationDbContext db,
          ICurrentUser currentUser)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
            _cUser = currentUser;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public IList<SocialProfiles> SocialProfiles { get; set; }
        public async Task OnGetAsync()
        {
            var _socialProfiles = await _db.SocialProfiles.Where(a => a.AppUsers.Id == _cUser.User.Id).ToListAsync();
            List<SocialProfiles> ListSocialLinks = new List<SocialProfiles>();
            if (_socialProfiles.Count > 0)
            {
                foreach (var item in Enum.GetValues(typeof(Helpers.Enums.SocialProfiles)))
                {
                    var valName = item.GetType().GetMember(item.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>(false)?.GetName() ?? item.ToString();
                    var su = _socialProfiles.Where(a => a.Name == item.ToString()).FirstOrDefault();
                    if (su != null)
                    {
                        SocialProfiles socialLinks = new SocialProfiles()
                        {
                            Name = su.Name,
                            PublicName = su.PublicName,
                            Url = su.Url,
                            Id = su.Id
                        };
                        ListSocialLinks.Add(socialLinks);
                    }
                    else
                    {
                        SocialProfiles socialLinks = new SocialProfiles()
                        {
                            Name = item.ToString(),
                            PublicName = valName,
                            Id = Guid.NewGuid()
                        };
                        ListSocialLinks.Add(socialLinks);
                    }

                }
            }

            else
            {
                foreach (var item in Enum.GetValues(typeof(Helpers.Enums.SocialProfiles)))
                {
                    var valName = item.GetType().GetMember(item.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>(false)?.GetName() ?? item.ToString();
                    SocialProfiles socialLinks = new SocialProfiles()
                    {
                        Name = item.ToString(),
                        PublicName = valName,
                        Id = Guid.NewGuid()
                    };
                    ListSocialLinks.Add(socialLinks);
                }
            }
            SocialProfiles = ListSocialLinks;
            //return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            bool success = false;
            var DbsocialLinks = await _db.SocialProfiles.Where(a => a.AppUsers.Id == _cUser.User.Id).ToListAsync();
            if (DbsocialLinks.Count > 0)
            { 
                _db.SocialProfiles.RemoveRange(DbsocialLinks);
            }

            if (SocialProfiles.Count > 0)
            {
                for (int i = 0; i < SocialProfiles.Count; i++)
                {
                    if (SocialProfiles[i].Url != null || !string.IsNullOrWhiteSpace(SocialProfiles[i].Url))
                    {
                        SocialProfiles links = new SocialProfiles
                        {
                            Id = Guid.NewGuid(),
                            Url = SocialProfiles[i].Url,
                            Name = SocialProfiles[i].Name,
                            PublicName = SocialProfiles[i].PublicName,
                            AppUsers = _cUser.User
                        };
                        _db.SocialProfiles.Add(links);                        
                    }
                }
                await _db.SaveChangesAsync();
                success = true;
            }
            StatusMessage = success ? "Your Profile has been updated." : "Some error occurred while saving. Please try again later.";
            return RedirectToPage();
        }
    }
}
