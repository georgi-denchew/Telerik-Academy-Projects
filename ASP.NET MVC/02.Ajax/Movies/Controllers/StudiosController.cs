using Movies.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class StudiosController : Controller
    {
        //
        // GET: /Studios/
        public ActionResult Index(int? id)
        {
            var context = new Entities();
            
            if (id != null && Request.IsAjaxRequest())
            {
                var studio = context.Studios.Include("Movies").FirstOrDefault(st => st.StudioId == id);
                return PartialView("_StudioDetails", studio);
            }

            return View(context.Studios.ToList());
        }

        public ActionResult Edit(int? id)
        {
            var context = new Entities();

            var studio = context.Studios.Include("Movies").FirstOrDefault(st => st.StudioId == id);

            return PartialView("_StudioEdit", studio);
        }

        public ActionResult Update(int? id, Studio model)
        {
            var context = new Entities();
            var studio = context.Studios.Find(id);
            studio.StudioName = model.StudioName;
            studio.StudioAddress = model.StudioAddress;
            context.SaveChanges();

            return View("Index", context.Studios.ToList());
        }

        public ActionResult Delete(int? id)
        {
            var context = new Entities();
            var studio = context.Studios.Find(id);
            context.Movies.RemoveRange(studio.Movies);
            context.Studios.Remove(studio);
            context.SaveChanges();

            return View("Index", context.Studios.ToList());
        }

        public ActionResult CreateNew()
        {
            return PartialView("_StudioAdd");
        }

        public ActionResult Add(Studio studio)
        {
            var context = new Entities();
            context.Studios.Add(studio);
            context.SaveChanges();

            return View("Index", context.Studios.ToList());
        }
	}
}