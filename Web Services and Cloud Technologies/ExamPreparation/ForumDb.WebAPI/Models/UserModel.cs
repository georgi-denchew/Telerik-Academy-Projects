using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ForumDb.WebAPI.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name="username")]
        public string Username { get; set; }

        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}