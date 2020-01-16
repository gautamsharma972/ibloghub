using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iBlogHub.Data
{
    public class TagsPostsRelations
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        
        public virtual Posts Posts { get; set; }

        [Key]
        [Column(Order = 2)]
        public virtual Tags Tags { get; set; }
    }
}
