using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDb.WebAPI.Models
{
    public class VoteModel
    {
        public int Value { get; set; }

        public string CreatedBy { get; set; }
    }
}