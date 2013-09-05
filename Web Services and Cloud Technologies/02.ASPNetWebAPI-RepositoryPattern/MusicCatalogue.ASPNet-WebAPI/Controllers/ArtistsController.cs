using MusicCatalogue.ASPNet_WebAPI.Models;
using MusicCatalogue.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;

namespace MusicCatalogue.ASPNet_WebAPI.Controllers
{
    public class ArtistsController : ApiController
    {
        private UnitOfWork unitOfWork;

        public ArtistsController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public ArtistsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ArtistModel> GetAll()
        {
            return this.unitOfWork.ArtistsRepository.All()
                .Select(ArtistModel.FromArtist).ToList();
        }

        public ArtistModel Get(int ID)
        {
            var artist = this.unitOfWork.ArtistsRepository.Get(ID);
            
            ArtistModel generatedArtistModel = ArtistModel.CreateModel(artist);

            return generatedArtistModel;
        }

        public HttpResponseMessage Post([FromBody]ArtistModel artistModel)
        {
            var artist = artistModel.CreateArtist();
            this.unitOfWork.ArtistsRepository.Add(artist);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + artist.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public HttpResponseMessage Put(int ID, [FromBody]ArtistModel artistModel)
        {
            var artist = artistModel.CreateArtist();
            this.unitOfWork.ArtistsRepository.Update(ID, artist);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.OK);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + artist.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public void Delete(int ID)
        {
            this.unitOfWork.ArtistsRepository.Delete(ID);

        }
    }
}
