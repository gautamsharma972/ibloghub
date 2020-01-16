using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class PostsInputModel
    {
        [UIHint("hidden")]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Your Post must have a title!")]
        [Display(Name = "Post Title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please write something for your Post.")]
        [Display(Name = "Description")]
        [DataType(DataType.Html)]
        public string Description { get; set; }

        [Display(Name = "Featured Image")]
        public IFormFile FeaturedImage { get; set; }

        [Display(Name ="Attach Podcasts")]
        public IFormFile Podcast { get; set; }

        [Display(Name = "Change your Post Excerpt")]
        [DataType(DataType.MultilineText)]
        [StringLength(255, MinimumLength =26, ErrorMessage ="Summary must be of minimum 26 words")]
        public string Excerpt { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }

        [Display(Name = "Enable/Disable Comments")]
        public bool CommentStatus { get; set; } = true;

        public string PostStatus { get; set; }

        public string PostFeaturedImage { get; set; }

        [TempData]
        public string Message { get; set; }

        public bool HasMessage => Message == null ? false : true;

        [TempData]
        public string MessageClass { get; set; }

       // [TempData]
        public bool isCategorySelected { get; set; }

        public string SelectedCategoryName { get; set; }
    }
}
