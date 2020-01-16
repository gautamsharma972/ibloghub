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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string slug { get; set; }

        public CategoryStatus Status { get; set; }

        public AppUsers CreatedBy { get; set; }

        public string Image { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }

        
    }
}
