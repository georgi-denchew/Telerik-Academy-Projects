using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MusicCatalogue.ASPNet_WebAPI.Models
{
    public class SongModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return x => new SongModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Year = x.Year,
                    Genre = x.Genre
                };
            }
        }

        public static SongModel CreateModel(Song song)
        {
            return new SongModel
            {
                Genre = song.Genre,
                Title = song.Title,
                Year = song.Year
            };
        }


        internal Song CreateSong()
        {
            return new Song { Year = this.Year, Genre = this.Genre, Title = this.Title, ID = this.ID };
        }


        internal void UpdateSong(SongModel song)
        {
            if (this.Title != null)
            {
                song.Title = this.Title;
            }

            if (this.Year != 0)
            {
                song.Year = this.Year;
            }

            if (this.Genre != null)
            {
                song.Genre = this.Genre;
            }
        }
    }
}