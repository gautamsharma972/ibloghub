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
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Posts Posts { get; set; }

        public AppUsers Author { get; set; }

        public string AuthorWebsite { get; set; }

        public DateTime CommentDate { get; set; }

        public string CommentContent { get; set; }

        public CommentStatus CommentStatus { get; set; }

        public Guid CommentParent { get; set; }

    }
}
