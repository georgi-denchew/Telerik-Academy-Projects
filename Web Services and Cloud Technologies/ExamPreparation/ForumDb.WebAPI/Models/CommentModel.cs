using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDb.WebAPI.Models
{
    public class CommentModel
    {
        public DateTime CommentDate { get; set; }

        public string CreatedBy { get; set; }

        public string Content { get; set; }
    }
}