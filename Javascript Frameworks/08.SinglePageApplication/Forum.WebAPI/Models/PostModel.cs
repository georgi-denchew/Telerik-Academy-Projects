using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Forum.WebAPI.Models
{
    [DataContract]
    public class PostModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }
    }
}