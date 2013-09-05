using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicCatalog.Models;
using _01.MusicCatalog.Data;

namespace MusicCatalog_Web_API.Controllers
{
    public class AlbumsController : ApiController
    {
        private MusicCatalogContext db = new MusicCatalogContext();

        public AlbumsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/Albums
        public IEnumerable<Album> GetAlbums()
        {
            return db.Albums.AsEnumerable();
        }

        // GET api/Albums/5
        public Album GetAlbum(int id)
        {
            Album album = db.Albums.Include("Songs").Include("Artists").FirstOrDefault(x => x.ID == id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Albums
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}