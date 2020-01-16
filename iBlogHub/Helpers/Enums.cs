using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Helpers
{
    public class Enums
    {
        public enum Gender
        {
            Male = 0,
            Female =1
        }

        public enum PostStatus
        {
            Published = 1,
            Draft = 2,
            Trashed = 3
        }

        public enum CommentStatus
        {
            Allowed = 1,
            Blocked =0
        }

        public enum CategoryStatus
        {
            Requested =0,
            Approved =1
        }

        public enum TermType
        {
            Category =1,
            Tags =2
        }

        public enum ErrorType
        {
            Page = 0,
            Posts =1,
            Application = 2
        }

        public enum SocialProfiles
        {
            [Display(Name = "Facebook")]
            Facebook = 1,

            [Display(Name = "Twitter")]
            Twitter = 2,

            [Display(Name = "Instagram")]
            Instagram = 3,

            [Display(Name = "Stack Overflow")]
            StackOverflow = 4,

            [Display(Name = "LinkedIn")]
            LinkedIn = 5,
            
            [Display(Name = "Buy me a Coffee", Description = "Add your Buy me a Coffee link, so users can donate directly to you account.")]
            BuyMeACoffee = 6,

            [Display(Name = "GitHub")]
            GitHub = 7,
        }

        public enum BookmarkType
        {
            Posts = 1,
            TextHighlights = 2
        }

        public enum BookmarkStatus
        {
            Added = 1,
            AlreadyExists = 0
        }
    }
}
