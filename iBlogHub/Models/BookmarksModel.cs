using iBlogHub.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class BookmarksModel
    {
        public IList<PostsViewModel> Posts { get; set; }
        public Guid Id { get; set; }
        public AppUsers Users { get; set; }
    }
}
