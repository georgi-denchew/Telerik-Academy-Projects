using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.Application.ViewModels
{
    public class SendTweetModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "Tweet should be between {2} and {1} symbols.")]
        public string Content { get; set; }

        [Required(ErrorMessage= "At least one hashtag should be entered")]
        public string Tags { get; set; }
    }
}