﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlogSystem.WebAPI.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name="username")]
        public string Username { get; set; }

        [DataMember(Name="displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name="authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name="sessionKey")]
        public string SessionKey { get; set; }
    }
}