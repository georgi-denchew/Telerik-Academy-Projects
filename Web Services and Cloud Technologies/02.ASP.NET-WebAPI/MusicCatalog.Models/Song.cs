using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MusicCatalog.Models
{
    [DataContract(IsReference = true)]
    public class Song
    {
        public Song()
        {
            this.Artists = new HashSet<Artist>();
            this.Albums = new HashSet<Album>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime? Year { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public ICollection<Artist> Artists { get; set; }

        [DataMember]
        public ICollection<Album> Albums { get; set; }
    }
}
