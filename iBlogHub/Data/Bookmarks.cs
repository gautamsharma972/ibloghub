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
    public class Bookmarks
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order =2)]
        public Posts Posts { get; set; }

        public AppUsers Users { get; set; }

        public DateTime AddedOn { get; set; }

        public BookmarkType BookmarkType { get; set; }
    }
}
