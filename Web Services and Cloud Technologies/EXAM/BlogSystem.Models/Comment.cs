using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BlogSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="ntext")]
        [MinLength(2)]
        public string Text { get; set; }

        [Required]
        public string CommentedBy { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
