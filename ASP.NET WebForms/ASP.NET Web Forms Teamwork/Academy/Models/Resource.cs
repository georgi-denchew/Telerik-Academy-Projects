using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}