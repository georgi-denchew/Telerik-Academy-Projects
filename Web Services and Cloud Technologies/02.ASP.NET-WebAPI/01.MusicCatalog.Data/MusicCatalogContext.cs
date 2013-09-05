using MusicCatalog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MusicCatalog.Data
{
    public class MusicCatalogContext : DbContext
    {
        public MusicCatalogContext() : base("MusicCatalogue")
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}
