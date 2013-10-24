using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace KendoMVCDemo.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public virtual Category Category { get; set; }
    }
}
