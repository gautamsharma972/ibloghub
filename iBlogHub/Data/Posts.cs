using iBlogHub.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static iBlogHub.Helpers.Enums;

namespace iBlogHub.Data
{
    public class Posts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public AppUsers Author { get; set; }

        public DateTime PostDate { get; set; }

        public string PostContent { get; set; }

        public string PostTitle { get; set; }

        public string Excerpt { get; set; }

        public PostStatus Status { get; set; }

        public CommentStatus CommentStatus { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int CommentCount { get; set; }

        public string FeaturedImage { get; set; }

        public ICollection<PostMedias> Medias { get; set; }

        public string slug { get; set; }

        public bool isVerified { get; set; }

        public virtual Category Category { get; set; }

        public long ViewsCount { get; set; }

        public virtual ICollection<TagsPostsRelations> TagsPostsRelations { get; set; }
    }
}
