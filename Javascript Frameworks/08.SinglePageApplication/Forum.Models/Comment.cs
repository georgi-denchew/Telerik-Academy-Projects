using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Forum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string PostedBy { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
