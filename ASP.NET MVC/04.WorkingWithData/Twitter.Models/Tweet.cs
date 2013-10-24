using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength=4, ErrorMessage="Tweet should be between {2} and {1} symbols.")]
        public string Content { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }
    }
}