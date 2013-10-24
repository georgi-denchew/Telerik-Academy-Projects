using Movies.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class UpdateMovieModel
    {
        public Movy Movie { get; set; }

        public Studio Studio { get; set; }
    }
}