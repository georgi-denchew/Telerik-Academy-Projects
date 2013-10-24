using Kendo.Mvc.UI;
using KendoMVCDemo.Areas.Administration.ViewModels;
using KendoMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace KendoMVCDemo.Areas.Administration.Controllers
{
    //[Authorize(Roles="Admin")]
    public class BooksController : Controller
    {
        public BooksController()
        {
            this.Data = new ApplicationDbContext();
        }

        public ApplicationDbContext Data { get; set; }

        //
        // GET: /Administration/Books/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadBooks([DataSourceRequest]DataSourceRequest request)
        {
            var books = this.Data.Books.Include("Category").Select(DetailedBookViewModel.FromBook);

            return Json(books.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditBook(int? id)
        {
            var book = this.Data.Books.Find(id);

            return View(book);
        }

        public ActionResult UpdateBook([DataSourceRequest]DataSourceRequest request, DetailedBookViewModel model)
        {
            var category = this.Data.Categories.Find(model.CategoryId);

            if (model != null && ModelState.IsValid && category != null)
            {
                var book = this.Data.Books.FirstOrDefault(b => b.Id == model.Id);

                book.Title = model.Title;
                book.Author = model.Author;
                book.Content = model.Content;
                book.Category = category;
                this.Data.SaveChanges();

                model.Category = book.Category.Name;
                model.CategoryId = book.Category.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateBook([DataSourceRequest]DataSourceRequest request, CreateBookViewModel model)
        {
            ModelState.Remove("Category");

            var category = this.Data.Categories.FirstOrDefault(x => x.Id == model.CategoryId);

            Book newBook = new Book();
            newBook.Title = model.Title;
            newBook.Author = model.Author;
            newBook.Content = model.Content;
            newBook.Category = category;

            DetailedBookViewModel result = new DetailedBookViewModel();


            if (model != null && ModelState.IsValid && category != null)
            {
                this.Data.Books.Add(newBook);
                this.Data.SaveChanges();

                result = new DetailedBookViewModel()
                {
                    Author = newBook.Author,
                    Category = newBook.Category.Name,
                    CategoryId = newBook.Category.Id,
                    Content = newBook.Content,
                    Id = newBook.Id,
                    Title = newBook.Title
                };
            }

            return Json(new[] { result }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBook([DataSourceRequest]DataSourceRequest request, DetailedBookViewModel model)
        {
            var book = this.Data.Books.FirstOrDefault(b => b.Id == model.Id);

            if (book != null)
            {
                this.Data.Books.Remove(book);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}