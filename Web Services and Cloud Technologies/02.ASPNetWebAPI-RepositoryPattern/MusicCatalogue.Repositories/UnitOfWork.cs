using MusicCatalogue.Data;
using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue.Repositories
{
    public class UnitOfWork: IDisposable
    {
        private MusicCatalogueContext context = new MusicCatalogueContext();
        private EfRepository<Album> albumsRepository;
        private EfRepository<Artist> artistsRepository;
        private EfRepository<Song> songsRepository;
        private bool disposed;

        public EfRepository<Album> AlbumsRepository 
        { 
            get
            {
                if (this.albumsRepository == null)
                {
                    this.albumsRepository = new EfRepository<Album>(context);
                }

                return this.albumsRepository;
            }
        }

        public EfRepository<Artist> ArtistsRepository 
        { 
            get
            {
                if (this.artistsRepository == null)
                {
                    this.artistsRepository = new EfRepository<Artist>(context);
                }

                return this.artistsRepository;
            }
        }

        public EfRepository<Song> SongsRepository
        {
            get
            {
                if (this.songsRepository == null)
                {
                    this.songsRepository = new EfRepository<Song>(context);
                }

                return this.songsRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
