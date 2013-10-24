using Movies.DataModel;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/
        public ActionResult Index(int? id)
        {
            var context = new Entities();
            var movieModels = context.Movies.Include("Studio").ToList();

            if (Request.IsAjaxRequest() && id != null)
            {
                var movieModel = movieModels.FirstOrDefault(movie => movie.MovieId == id);
                return PartialView("_MovieDetails", movieModel);
            }

            return View(movieModels);
        }

        public ActionResult EditIndex(int? id)
        {
            var context = new Entities();
            var movieModels = context.Movies.Include("Studio").ToList();
            var movieModel = movieModels.FirstOrDefault(movie => movie.MovieId == id);
            var studioModels = context.Studios.ToList();

            EditMovieModel model = new EditMovieModel();
            model.Movie = movieModel;
            model.Studios = studioModels;

            return PartialView("_MovieEdit", model);
        }

        [HttpPost]
        public ActionResult Update(Movy model, int id)
        {
            var context = new Entities();
            var movies = context.Movies;
            var movie = movies.FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie");
            }

            movie.Director = model.Director;
            movie.LeadingFemaleRole = model.LeadingFemaleRole;
            movie.LeadingMaleRole = model.LeadingMaleRole;
            movie.Studio = context.Studios.FirstOrDefault(st => st.StudioId == model.StudioId);
            movie.Title = model.Title;
            movie.Year = model.Year;

            context.SaveChanges();

            return View("Index", context.Movies.ToList());
        }

        public ActionResult CreateNew()
        {
            var context = new Entities();
            var studioModels = context.Studios.ToList();

            return PartialView("_MovieAdd", studioModels);
        }

        public ActionResult Add(Movy model)
        {
            var context = new Entities();
            var studio = context.Studios.FirstOrDefault(st => st.StudioId == model.StudioId);
            studio.Movies.Add(model);
            context.SaveChanges();

            return View("Index", context.Movies.ToList());
        }

        public ActionResult Delete(int? id)
        {
            var context = new Entities();
            var movie = context.Movies.Find(id);
            context.Movies.Remove(movie);
            context.SaveChanges();

            return View("Index", context.Movies.ToList());
        }
    }
}