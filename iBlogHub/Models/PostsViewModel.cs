using iBlogHub.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Models
{
    public class PostsViewModel
    {
        [UIHint("Hidden")]
        public Guid Id { get; set; }

        public AppUsers Author { get; set; }

        public DateTime PostDate { get; set; }

        [Required(ErrorMessage ="You can not post without any contents.")]
        [DataType(DataType.Html)]        
        [Display(Name ="Description")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "You can not post without a Title.")]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        public string Excerpt { get; set; }

        public PostStatus Status { get; set; }

        public string ViewCategory { get; set; }

        [JsonIgnore]
        public CategoryViewModel Category { get; set; }

        //[Required]
        [Display(Name ="Would you like to enable comments for your Post?")]
        public CommentStatus CommentStatus { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int CommentCount { get; set; }

        [Display(Name ="Featured Image")]
        [DataType(DataType.Upload)]
        public string FeaturedImage { get; set; }

        //public ICollection<PostMedias> Medias { get; set; }

        public string slug { get; set; }

        [TempData]
        public string Message { get; set; }

        public bool HasMessage => Message == null ? false : true;

        [TempData]
        public string MessageClass { get; set; }

        [JsonIgnore]
        public IList<TagsInput> Tags { get; set; }

        public bool isVerified { get; set; }

        public long ViewsCount { get; set; }
    }
}
