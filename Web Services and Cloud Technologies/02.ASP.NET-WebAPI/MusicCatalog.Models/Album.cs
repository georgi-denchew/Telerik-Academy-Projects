using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MusicCatalog.Models
{
    [DataContract(IsReference = true)]
    public class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime? Year { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public ICollection<Artist> Artists { get; set; }

        [DataMember]
        public ICollection<Song> Songs { get; set; }
    }
}
