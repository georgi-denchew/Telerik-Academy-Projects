﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogSystem.WebAPI.Models
{
    [DataContract]
    public class PostResponseModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }
    }
}