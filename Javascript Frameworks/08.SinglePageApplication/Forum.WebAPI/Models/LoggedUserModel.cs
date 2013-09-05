using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Forum.WebAPI.Models
{
    [DataContract]
    public class LoggedUserModel
    {
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}