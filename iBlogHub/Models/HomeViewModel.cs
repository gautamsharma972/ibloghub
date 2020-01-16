using iBlogHub.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class HomeViewModel
    {
        public IList<PostsViewModel> Articles { get; set; }

        public IList<CategoryViewModel> CategoriesModel { get; set; }

        public AppUsers User { get; set; }

        public Newsletters Newsletters { get; set; }
    }
}
