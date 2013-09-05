using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.Models
{
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
