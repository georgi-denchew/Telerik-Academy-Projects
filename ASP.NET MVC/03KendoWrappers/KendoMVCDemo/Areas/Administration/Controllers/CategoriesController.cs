using KendoMVCDemo.Models;
using KendoMVCDemo.ViewModels;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace KendoMVCDemo.Areas.Administration.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {
            this.Data = new ApplicationDbContext();
        }

        public ApplicationDbContext Data { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.Data.Categories.Select(CategoryViewModel.FromCategory);

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel model)
        {
            var category = this.Data.Categories.Find(model.Id);

            if (category != null && ModelState.IsValid)
            {
                category.Name = model.Name;
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel model)
        {
            var category = this.Data.Categories.Find(model.Id);

            if (category != null)
            {
                this.Data.Categories.Remove(category);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel model)
        {
            Category category = new Category();
            category.Name = model.Name;

            this.Data.Categories.Add(category);
            this.Data.SaveChanges();

            model.Id = category.Id;

            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCategories()
        {
            var categories = this.Data.Categories.Select(CategoryViewModel.FromCategory).ToList();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
	}
}