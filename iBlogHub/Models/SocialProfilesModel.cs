using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class SocialProfilesModel
    {
        [UIHint("Hidden")]
        public Guid Id { get; set; }

        public string PublicName { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}
