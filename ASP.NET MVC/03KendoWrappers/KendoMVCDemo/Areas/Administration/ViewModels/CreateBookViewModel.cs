using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoMVCDemo.Areas.Administration.ViewModels
{
    public class CreateBookViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
    }
}