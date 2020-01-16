using System;
using System.Collections.Generic;

namespace iBlogHub.Models
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string slug { get; set; }
        public string Image { get; set; }
        public IList<PostsViewModel> Posts { get; set; }
    }
}