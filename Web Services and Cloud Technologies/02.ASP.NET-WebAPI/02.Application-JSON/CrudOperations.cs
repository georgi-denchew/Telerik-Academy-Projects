using MusicCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace _02.Application_JSON
{
    public class CrudOperations
    {
        public static void AddSong(HttpClient client, Song song)
        {
           bool isJsonContentType = IsJsonContentType(client);

            HttpResponseMessage result = new HttpResponseMessage();

            if (isJsonContentType)
            {
                result = client.PostAsJsonAsync("api/songs", song).Result;
            }
            else
            {
                result = client.PostAsXmlAsync("api/songs", song).Result;
            }
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added");
            }
            else
            {
                Console.WriteLine(result.StatusCode + " " + result.ReasonPhrase);
            }
        }

        private static bool IsJsonContentType(HttpClient client)
        {
            return client.DefaultRequestHeaders.Accept.ToString() == "application/json";
        }

        public static void UpdateSong(HttpClient client, Song song)
        {
            bool isJsonContentType = IsJsonContentType(client);

            HttpResponseMessage result = new HttpResponseMessage();

            if (isJsonContentType)
            {
                result = client.PutAsJsonAsync("api/songs/" + song.ID, song).Result;
            }
            else
            {
                result = client.PutAsXmlAsync("api/songs/" + song.ID, song).Result;
            }
                        
            if(result.IsSuccessStatusCode)
            {
                Console.WriteLine("Song with ID {0} updated successfully", song.ID);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        public static void DeleteSong(HttpClient client, int ID)
        {
            var result = client.DeleteAsync("api/songs/" + ID).Result;

            if(result.IsSuccessStatusCode)
            {
                Console.WriteLine("Song with ID {0} deleted successfully",
                    ID);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        public static Song GetSong(HttpClient client, int ID)
        {
            var response = client.GetAsync("api/songs/" + ID).Result;
            
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Song>().Result;
            }
            else
            {
                Console.WriteLine("No song exists with the ID {0}", ID);
                return null;
            }
        }

        public static IEnumerable<Song> GetSongs(HttpClient client)
        {
            return client.GetAsync("api/songs").Result.Content.ReadAsAsync<IEnumerable<Song>>().Result;
        }

        public static void AddAlbum(HttpClient client, Album album)
        {
            bool isJsonContentType = IsJsonContentType(client);

            HttpResponseMessage result = new HttpResponseMessage();

            if (isJsonContentType)
            {
                result = client.PostAsJsonAsync("api/albums/" + album.ID, album).Result;
            }
            else
            {
                result = client.PostAsXmlAsync("api/albums/" + album.ID, album).Result;
            }

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added");
            }
            else
            {
                Console.WriteLine(result.StatusCode + " " + result.ReasonPhrase);
            }
        }

        public static void UpdateAlbum(HttpClient client, Album album)
        {
            bool isJsonContentType = IsJsonContentType(client);

            HttpResponseMessage result = new HttpResponseMessage();

            if (isJsonContentType)
            {
                result = client.PutAsJsonAsync("api/albums/" + album.ID, album).Result;
            }
            else
            {
                result = client.PutAsXmlAsync("api/albums/" + album.ID, album).Result;
            }

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Album with ID {0} updated successfully", album.ID);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        public static void DeleteAlbum(HttpClient client, int ID)
        {
            var result = client.DeleteAsync("api/albums/" + ID).Result;

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Album with ID {0} deleted successfully",
                    ID);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        public static Album GetAlbum(HttpClient client, int ID)
        {
            var response = client.GetAsync("api/albums/" + ID).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Album>().Result;
            }
            else
            {
                Console.WriteLine("No song exists with the ID {0}", ID);
                return null;
            }
        }

        public static IEnumerable<Album> GetAlbums(HttpClient client)
        {
            return client.GetAsync("api/albums").Result.Content.ReadAsAsync<IEnumerable<Album>>().Result;
        }

        public static void AddArtist(HttpClient client, Artist artist)
        {
            bool isJsonContentType = IsJsonContentType(client);

            HttpResponseMessage result = new HttpResponseMessage();

            if (isJsonContentType)
            {
                result = client.PostAsJsonAsync("api/artists", artist).Result;
            }
            else
            {
                result = client.PostAsXmlAsync("api/artists", artist).Result;
            }

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added");
            }
            else
            {
                Console.WriteLine(result.StatusCode + " " + result.ReasonPhrase);
            }
        }

        public static void UpdateArtist(HttpClient client, Artist artist)
        {
            bool isJsonContentType = IsJsonContentType(client);

            HttpResponseMessage result = new HttpResponseMessage();

            if (isJsonContentType)
            {
                result = client.PutAsJsonAsync("api/artists/" + artist.ID, artist).Result;
            }
            else
            {
                result = client.PutAsXmlAsync("api/artists/" + artist.ID, artist).Result;
            }

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist with ID {0} updated successfully", artist.ID);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        public static void DeleteArtist(HttpClient client, int ID)
        {
            var result = client.DeleteAsync("api/artists/" + ID).Result;

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist with ID {0} deleted successfully",
                    ID);
            }
            else
            {
                Console.WriteLine(result.ReasonPhrase);
            }
        }

        public static Artist GetArtist(HttpClient client, int ID)
        {
            var response = client.GetAsync("api/artists/" + ID).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Artist>().Result;
            }
            else
            {
                Console.WriteLine("No song exists with the ID {0}", ID);
                return null;
            }
        }

        public static IEnumerable<Artist> GetArtists(HttpClient client)
        {
            return client.GetAsync("api/artists").Result.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
        }
    }
}
