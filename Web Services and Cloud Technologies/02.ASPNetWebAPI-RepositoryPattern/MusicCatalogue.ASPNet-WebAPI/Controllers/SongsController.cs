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
    public class SongsController : ApiController
    {
        private UnitOfWork unitOfWork;

        public SongsController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public SongsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<SongModel> GetAll()
        {
            return this.unitOfWork.SongsRepository.All()
                .Select(SongModel.FromSong).ToList();
        }

        public SongModel Get(int ID)
        {
            var song = this.unitOfWork.SongsRepository.Get(ID);
            
            SongModel generatedSongModel = SongModel.CreateModel(song);

            return generatedSongModel;
        }

        public HttpResponseMessage Post([FromBody]SongModel songModel)
        {
            var song = songModel.CreateSong();
            this.unitOfWork.SongsRepository.Add(song);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + song.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public HttpResponseMessage Put(int ID, [FromBody]SongModel songModel)
        {
            var song = songModel.CreateSong();

            this.unitOfWork.SongsRepository.Update(ID, song);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.OK);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + song.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public void Delete(int ID)
        {
            this.unitOfWork.SongsRepository.Delete(ID);
        }
    }
}
