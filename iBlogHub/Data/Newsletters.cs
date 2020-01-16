using System;
using System.ComponentModel.DataAnnotations;

namespace iBlogHub.Models
{
    public class Newsletters
    {
        [ScaffoldColumn(false)]
        public Guid id { get; set; }

        [EmailAddress]
        [Display(Name="Email Adress")]
        [Required(ErrorMessage ="Please enter your Email Id")]
        public string Email { get; set; }

        public string Name { get; set; }

        public bool isVerified { get; set; }

        public DateTime SubscribedOn { get; set; }

        public int TotalSent { get; set; }

        public bool isSent { get; set; }
    }
}