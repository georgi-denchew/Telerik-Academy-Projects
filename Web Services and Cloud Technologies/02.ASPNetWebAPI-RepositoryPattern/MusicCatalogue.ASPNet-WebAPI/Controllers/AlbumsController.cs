using MusicCatalogue.ASPNet_WebAPI.Models;
using MusicCatalogue.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicCatalogue.ASPNet_WebAPI.Controllers
{
    public class AlbumsController : ApiController
    {
        private UnitOfWork unitOfWork;

        public AlbumsController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public AlbumsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<AlbumModel> GetAll()
        {
            return this.unitOfWork.AlbumsRepository.All()
                .Select(AlbumModel.FromAlbum).ToList();
        }

        public AlbumModel Get(int ID)
        {
            var album = this.unitOfWork.AlbumsRepository.Get(ID);

            AlbumModel generatedAlbumModel = AlbumModel.CreateModel(album);

            return generatedAlbumModel;
        }

        public HttpResponseMessage Post([FromBody]AlbumModel albumModel)
        {
            var album = albumModel.CreateAlbum();
            this.unitOfWork.AlbumsRepository.Add(album);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + album.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public HttpResponseMessage Put(int ID, [FromBody]AlbumModel albumModel)
        {
            var album = albumModel.CreateAlbum();
            this.unitOfWork.AlbumsRepository.Update(ID, album);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.OK);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + album.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public void Delete(int ID)
        {
            this.unitOfWork.AlbumsRepository.Delete(ID);
        }
    }
}
