using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class NextPreviousPostsModel
    {
        public PostsViewModel PreviousPost { get; set; }
        public PostsViewModel NextPost { get; set; }
    }
}
