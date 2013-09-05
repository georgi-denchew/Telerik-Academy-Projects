using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MusicCatalog.Models
{
    [DataContract(IsReference = true)]
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        [DataMember]
        public ICollection<Album> Albums { get; set; }

        [DataMember]
        public ICollection<Song> Songs { get; set; }
    }
}
