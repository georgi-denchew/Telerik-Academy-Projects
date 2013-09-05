using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string PostedBy { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
