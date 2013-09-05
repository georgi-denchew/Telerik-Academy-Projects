using MusicCatalogue.ASPNet_WebAPI.Controllers;
using MusicCatalogue.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MusicCatalogue.ASPNet_WebAPI.DependencyResolver
{
    public class DbDependencyResolver : IDependencyResolver
    {

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if(serviceType == typeof(ArtistsController))
            {
                return new ArtistsController(new UnitOfWork());
            }
            else if(serviceType == typeof(AlbumsController))
            {
                return new AlbumsController(new UnitOfWork());
            }
            else if(serviceType == typeof(SongsController))
            {
                return new SongsController(new UnitOfWork());
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }

}