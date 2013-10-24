using KendoMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace KendoMVCDemo.Areas.Administration.ViewModels
{
    public class DetailedBookViewModel
    {
        public static Expression<Func<Book, DetailedBookViewModel>> FromBook
        {
            get
            {
                return book => new DetailedBookViewModel
                {
                    Id = book.Id,
                    Author = book.Author,
                    Content = book.Content,
                    Category = book.Category.Name,
                    Title = book.Title,
                    CategoryId = book.Category.Id
                };
            }
        }

        //[HiddenInput(DisplayValue=false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

        public int CategoryId { get; set; }
    }
}