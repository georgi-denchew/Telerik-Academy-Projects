using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MusicCatalogue.ASPNet_WebAPI.Models
{
    public class AlbumModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }

        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return x => new AlbumModel
                {
                    Producer = x.Producer,
                    Title = x.Title,
                    Year = x.Year
                };
            }
        }

        public static AlbumModel CreateModel(Album album)
        {
            return new AlbumModel
            {
                Title = album.Title,
                Year = album.Year,
                Producer = album.Producer
            };
        }

        public Album CreateAlbum()
        {
            return new Album
            {
                Year = this.Year,
                Title = this.Title,
                Producer = this.Producer
            };
        }
    }
}