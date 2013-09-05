using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalogue.ASPNet_WebAPI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicCatalogue.Models;

namespace MusicCatalogue.Client
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:58911/") };

        static void Main(string[] args)
        {
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ArtistModel model = new ArtistModel { Country = "Bulgaria", DateOfBirth = DateTime.Now, Name = "pesho" };

            AddNewArtist(model);
        }

        private static void AddNewArtist(ArtistModel model)
        {
            //var response = Client.PostAsJsonAsync("api/artists", model).Result;





            //var response = Client.GetAsync("api/artists/" + 1).Result;

            //Console.WriteLine(response.StatusCode);
            //var result = Client.GetAsync("api/artists").Result.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result.FirstOrDefault();

            //result.Name = "new name";

            SongModel bla = new SongModel()
            {
                Title = "new title",
                Year = 2000,
                Genre = "blah",
                ID = 1
            };

            //var secondResponse = Client.GetAsync("api/songs/" + 1).Result;

            //var asd = Client.GetAsync("api/songs/" + 1).Result;

            //Console.WriteLine(secondResponse.StatusCode);

            //Console.WriteLine(bla.ID);


            //var qwerty = asd.Content.ReadAsAsync<SongModel>().Result;

            var third = Client.PutAsJsonAsync("api/songs/" + 1, bla).Result;

        }
    }
}
