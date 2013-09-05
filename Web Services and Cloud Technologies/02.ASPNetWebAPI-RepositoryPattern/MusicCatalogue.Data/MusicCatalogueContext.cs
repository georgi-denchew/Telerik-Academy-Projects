using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.Data
{
    public class MusicCatalogueContext : DbContext
    {
        public MusicCatalogueContext()
            : base("MusicCatalogue")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Song { get; set; }
    }
}
