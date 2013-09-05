using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebAPI.Models
{
    public class CommentModel
    {
        public string PostedBy { get; set; }

        public DateTime PostDate { get; set; }

        public string Text { get; set; }
    }
}