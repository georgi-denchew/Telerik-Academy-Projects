using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlogSystem.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
