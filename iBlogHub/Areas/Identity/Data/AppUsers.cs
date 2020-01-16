using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Areas.Identity.Data
{
    public class AppUsers : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string Photo { get; set; }

        public string PhotoPath { get; set; }

        [PersonalData]
        public DateTime Dob { get; set; }

        [PersonalData]
        public  DateTime DateJoined { get; set; }

        [PersonalData]
        public string About { get; set; }

        [PersonalData]
        public Gender Gender { get; set; }

        [JsonIgnore]
        [PersonalData]
        public virtual ICollection<SocialProfiles> SocialProfiles { get; set; }
    }
}
