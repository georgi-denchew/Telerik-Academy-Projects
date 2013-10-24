using Movies.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class EditMovieModel
    {
        public Movy Movie { get; set; }

        public IEnumerable<Studio> Studios { get; set; }
    }
}