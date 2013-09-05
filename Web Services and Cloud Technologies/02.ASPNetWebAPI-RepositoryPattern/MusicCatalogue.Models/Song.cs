using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicCatalogue.Models
{
    public class Song
    {
        public Song()
        {
            this.Albums = new HashSet<Album>();
            this.Artists = new HashSet<Artist>();
        }
        public int ID { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}
