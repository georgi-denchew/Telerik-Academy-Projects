using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueLibrary
{
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }
        public string Name { get; set; }
        public HashSet<Album> Albums { get; set; }
    }
}
