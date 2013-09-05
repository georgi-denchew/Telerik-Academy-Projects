using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MusicCatalogue.ASPNet_WebAPI.Models
{
    public class ArtistModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return x => new ArtistModel 
                { 
                    ID = x.ID, Name = x.Name, Country = x.Country, DateOfBirth = x.DateOfBirth 
                };
            }
        }

        public static ArtistModel CreateModel(Artist artist)
        {
            return new ArtistModel 
            { 
                Name = artist.Name, DateOfBirth = artist.DateOfBirth, Country = artist.Country 
            };
        }

        public Artist CreateArtist()
        {
            return new Artist { Name = this.Name, Country = this.Country, DateOfBirth = this.DateOfBirth };
        }

        public void UpdateArtist(Artist artist)
        {
            if (this.Name != null)
            {
                artist.Name = this.Name;
            }

            if (this.Country != null)
            {
                artist.Country = this.Country;
            }

            if (this.DateOfBirth != null)
            {
                artist.DateOfBirth = this.DateOfBirth;
            }
        }
    }
}