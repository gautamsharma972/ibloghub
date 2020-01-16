using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using iBlogHub.Areas.Identity.Data;
using iBlogHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(
            UserManager<AppUsers> userManager,
            SignInManager<AppUsers> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
        }

        public string Username { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage ="Please enter your First Name")]
            [Display(Name ="First Name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Please enter your Last Name")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "About you")]
            [UIHint("multiline")]
            public string About { get; set; }

            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Display(Name = "Birth Date (optional)")]
            [DataType(DataType.Date, ErrorMessage ="Invalid date! Please try again.")]
            public DateTime Dob { get; set; }

            public IList<Data.SocialProfiles> SocialProfiles { get; set; }

        }

        private async Task LoadAsync(AppUsers user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var _cuser = await _db.AppUsers.Where(a => a.UserName == userName).FirstOrDefaultAsync();

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                About = _cuser.About,
                Dob = _cuser.Dob,
                FirstName = _cuser.FirstName,
                Gender = _cuser.Gender,
                LastName = _cuser.LastName,
                //SocialProfiles = _cuser.SocialProfiles
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            var _dbUser = _db.AppUsers.Where(a => a.Id == user.Id).FirstOrDefault();
            _dbUser.About = Input.About;
            _dbUser.Dob = Input.Dob;
            _dbUser.FirstName = Input.FirstName;
            _dbUser.LastName = Input.LastName;
            _dbUser.Gender = Input.Gender;
            _db.SaveChanges();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated.";
            return RedirectToPage();
        }
    }
}
