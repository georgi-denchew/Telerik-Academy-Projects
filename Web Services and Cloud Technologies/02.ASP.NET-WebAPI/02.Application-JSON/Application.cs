using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicCatalog.Models;

namespace _02.Application_JSON
{
    class Application
    {
        private static HttpClient jsonClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:49945/")
        };

        private static HttpClient xmlClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:49945/")
        };

        static void Main(string[] args)
        {
            InitializeHeaders();

            Song song;
            Artist artist;
            Album album;
            InitializeSampleVariables(out song, out artist, out album);

            // the following two rows will work only with the JSON client 
            // and return internal server error when using the XML Client
            //song.Albums.Add(album);
            //song.Artists.Add(artist);

            SampleSongAdding(song);

            // get song from the database
            var songToEdit = jsonClient.GetAsync("api/songs/").Result.Content.
                ReadAsAsync<IEnumerable<Song>>().Result.FirstOrDefault();
            songToEdit.Title = "edited title";

            SampleSongUpdating(songToEdit);

            SampleSongReading(songToEdit);

            SampleSongsReading();

            SampleArtistAdding(artist);

            // get artist from the database
            var artistToEdit = jsonClient.GetAsync("api/artists/").Result.Content.ReadAsAsync<IEnumerable<Artist>>().Result.FirstOrDefault();
            artistToEdit.Name = "edited artist";

            SampleArtistUpdating(artistToEdit);

            SampleArtistReading(artistToEdit);

            SampleArtistsReading();

            SampleAlbumAdding(album);

            // get album from the database
            var albumToEdit = jsonClient.GetAsync("api/albums/").Result.Content.ReadAsAsync<IEnumerable<Album>>().Result.FirstOrDefault();
            albumToEdit.Title = "edited title";

            SampleAlbumUpdating(albumToEdit);

            SampleAlbumReceiving(albumToEdit);

            SampleAlbumsReceiving();

            SampleVariablesDeleting(songToEdit, artistToEdit, albumToEdit);
        }

        private static void SampleVariablesDeleting(Song songToEdit, Artist artistToEdit, Album albumToEdit)
        {
            // JSON Album Delete
            CrudOperations.DeleteAlbum(jsonClient, albumToEdit.ID);

            // XML Song Delete
            CrudOperations.DeleteSong(xmlClient, songToEdit.ID);

            // XML Artist Delete
            CrudOperations.DeleteArtist(xmlClient, artistToEdit.ID);
        }

        private static void SampleAlbumsReceiving()
        {
            // JSON Get All Albums
            var jsonAllAlbums = CrudOperations.GetAlbums(jsonClient);
            Console.WriteLine("All Albums:");
            foreach (var item in jsonAllAlbums)
            {
                Console.WriteLine("Title: {0}; Producer: {1}; Year: {2};", item.Title, item.Producer, item.Year);
            }

            // XML Get All Albums
            var xmlAllAlbums = CrudOperations.GetAlbums(xmlClient);
            Console.WriteLine("All Albums:");
            foreach (var item in xmlAllAlbums)
            {
                Console.WriteLine("Title: {0}; Producer: {1}; Year: {2};", item.Title, item.Producer, item.Year);
            }
        }

        private static void SampleAlbumReceiving(Album albumToEdit)
        {
            // JSON Get Album
            var jsonGottenAlbum = CrudOperations.GetAlbum(jsonClient, albumToEdit.ID);
            if (jsonGottenAlbum != null)
            {
                Console.WriteLine("Got album with ID {0}", jsonGottenAlbum.ID);
            }

            // XML Get Album
            var xmlGottenAlbum = CrudOperations.GetAlbum(xmlClient, albumToEdit.ID);
            if (xmlGottenAlbum != null)
            {
                Console.WriteLine("Got album with ID {0}", xmlGottenAlbum.ID);
            }
        }

        private static void SampleAlbumUpdating(Album albumToEdit)
        {
            // JSON Update Album
            CrudOperations.UpdateAlbum(jsonClient, albumToEdit);

            // XML Update Album
            CrudOperations.UpdateAlbum(xmlClient, albumToEdit);
        }

        private static void SampleAlbumAdding(Album album)
        {
            // JSON Add Album
            CrudOperations.AddAlbum(jsonClient, album);

            // XML Add Album
            CrudOperations.AddAlbum(xmlClient, album);
        }

        private static void SampleArtistsReading()
        {
            // JSON Get All Artists
            var jsonAllArtists = CrudOperations.GetArtists(jsonClient);
            Console.WriteLine("All Artists:");
            foreach (var item in jsonAllArtists)
            {
                Console.WriteLine("Name: {0}; Country: {1}; Date of birth: {2};", item.Name, item.Country, item.DateOfBirth);
            }

            // XML Get All Artists
            var xmlAllArtists = CrudOperations.GetArtists(xmlClient);
            Console.WriteLine("All Artists:");
            foreach (var item in xmlAllArtists)
            {
                Console.WriteLine("Name: {0}; Country: {1}; Date of birth: {2};", item.Name, item.Country, item.DateOfBirth);
            }
        }

        private static void SampleArtistReading(Artist artistToEdit)
        {
            // JSON Get Artist
            var jsonGottenArtist = CrudOperations.GetArtist(jsonClient, artistToEdit.ID);
            if (jsonGottenArtist != null)
            {
                Console.WriteLine("Got artist with ID {0}", jsonGottenArtist.ID);
            }

            // XML Get Artist
            var xmlGottenArtist = CrudOperations.GetArtist(xmlClient, artistToEdit.ID);
            if (xmlGottenArtist != null)
            {
                Console.WriteLine("Got artist with ID {0}", xmlGottenArtist.ID);
            }
        }

        private static void SampleArtistUpdating(Artist artistToEdit)
        {
            // JSON Update Artist
            CrudOperations.UpdateArtist(jsonClient, artistToEdit);

            // XML Update Artist
            CrudOperations.UpdateArtist(xmlClient, artistToEdit);
        }

        private static void SampleArtistAdding(Artist artist)
        {
            // JSON Add Artist
            CrudOperations.AddArtist(jsonClient, artist);

            // XML Add Artist
            CrudOperations.AddArtist(xmlClient, artist);
        }

        private static void SampleSongsReading()
        {
            // JSON Get All Songs
            var jsonAllSongs = CrudOperations.GetSongs(jsonClient);
            Console.WriteLine("All Songs:");
            foreach (var item in jsonAllSongs)
            {
                Console.WriteLine("Title: {0}; Genre: {1}; Year: {2};", item.Title, item.Genre, item.Year);
            }

            // XML Get All Songs
            var xmlAllSongs = CrudOperations.GetSongs(xmlClient);
            Console.WriteLine("All Songs:");
            foreach (var item in xmlAllSongs)
            {
                Console.WriteLine("Title: {0}; Genre: {1}; Year: {2};", item.Title, item.Genre, item.Year);
            }
        }

        private static void SampleSongReading(Song songToEdit)
        {
            // JSON Get Song
            var jsonGottenSong = CrudOperations.GetSong(jsonClient, songToEdit.ID);
            if (jsonGottenSong != null)
            {
                Console.WriteLine("Got song with ID {0}", jsonGottenSong.ID);
            }

            // XML Get Song
            var xmlGottenSong = CrudOperations.GetSong(xmlClient, songToEdit.ID);
            if (xmlGottenSong != null)
            {
                Console.WriteLine("Got song with ID {0}", xmlGottenSong.ID);
            }
        }

        private static void SampleSongUpdating(Song songToEdit)
        {
            // JSON Song update
            CrudOperations.UpdateSong(jsonClient, songToEdit);

            // XML Song update
            CrudOperations.UpdateSong(xmlClient, songToEdit);
        }

        private static void SampleSongAdding(Song song)
        {

            // JSON Song adding
            CrudOperations.AddSong(jsonClient, song);

            // XML Song adding
            CrudOperations.AddSong(xmlClient, song);
        }

        private static void InitializeSampleVariables(out Song song, out Artist artist, out Album album)
        {
            song = new Song
            {
                Title = "smoke on the fire",
                Genre = "rock"
            };

            artist = new Artist
            {
                Country = "Bulgaria",
                Name = "Peep Durple"
            };

            album = new Album
            {
                Producer = "Sony",
                Title = "Best hits",
                Year = DateTime.Now
            };
        }

        private static void InitializeHeaders()
        {

            jsonClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

            xmlClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/xml"));
        }
    }
}