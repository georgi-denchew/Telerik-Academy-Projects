using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Title { get; set; }
        
        [Required]
        public string PostedBy { get; set; }
        
        [Required]
        public DateTime PostDate { get; set; }
        
        [Required]
        [Column(TypeName="ntext")]
        [MinLength(10)]
        public string Text { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        
        [Required]
        public virtual User User { get; set; }
    }
}
