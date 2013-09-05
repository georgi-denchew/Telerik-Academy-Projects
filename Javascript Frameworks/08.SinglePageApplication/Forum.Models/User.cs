using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string Nickname { get; set; }

        [Required]
        [MinLength(40)]
        [MaxLength(40)]
        [StringLength(40)]
        public string AuthCode { get; set; }

        [MinLength(50)]
        [MaxLength(50)]
        [StringLength(50)]
        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
