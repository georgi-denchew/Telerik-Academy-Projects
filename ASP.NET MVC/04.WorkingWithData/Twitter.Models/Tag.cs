using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Twitter.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength=1, ErrorMessage="Tag should be between {1} and {2} symbols")]
        public string Title { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }
    }
}
