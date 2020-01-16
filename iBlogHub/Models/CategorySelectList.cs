using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Models
{
    public class CategorySelectList : SelectListItem
    {
        public string Image { get; set; }
    }

}
