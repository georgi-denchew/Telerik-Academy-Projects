using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogueLibrary
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public string Name { get; set; }

        public string Producer { get; set; }

        public DateTime Year { get; set; }

        public decimal Price { get; set; }

        public HashSet<Song> Songs { get; set; }
    }
}
