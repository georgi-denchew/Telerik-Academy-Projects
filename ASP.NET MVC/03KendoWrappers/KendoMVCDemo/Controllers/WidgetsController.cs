using Kendo.Mvc.UI;
using KendoMVCDemo.Models;
using KendoMVCDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoMVCDemo.Controllers
{
    public class WidgetsController : Controller
    {
        public WidgetsController()
        {
            this.Data = new ApplicationDbContext();
        }

        public ApplicationDbContext Data { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult AutoComplete()
        {
            var books = this.Data.Books.Select(ShortBookViewModel.FromBook);

            return View(books);
        }

        public JsonResult GetAutocompleteData(string text)
        {
            var books = this.Data.Books.
                            Where(book => book.Title.ToLower().Contains(text.ToLower()))
                            .Select(ShortBookViewModel.FromBook);

            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Saykor(string serversideautocomplete)
        {
            return null;
        }

        public ActionResult DropDownList()
        {
            var categories = this.Data.Categories.Select(CategoryViewModel.FromCategory);

            return View(categories);
        }

        public JsonResult GetCascadingBooks(int categoryId)
        {
            var selectedBooks = this.Data.Categories
                .FirstOrDefault(x => x.Id == categoryId)
                .Books.AsQueryable().Select(ShortBookViewModel.FromBook);

            return Json(selectedBooks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TreeView()
        {
            var result = this.Data.Categories.Include("Books").ToList().Select(x => new TreeViewItemModel
                {
                    Text = x.Name,
                    Items = x.Books.Select(y => new TreeViewItemModel
                    {
                        Text = y.Title,
                    }).ToList()
                });

            return View(result);
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var file in upload)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data/"), fileName);

                    file.SaveAs(physicalPath);
                }
            }

            return Content("");
        }

        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
    }
}