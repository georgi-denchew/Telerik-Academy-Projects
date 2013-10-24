using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.Models;
using Twitter.Data;
using Twitter.Application.ViewModels;

namespace Twitter.Application.Areas.Administrator.Controllers
{
    public class AdministrationController : Controller
    {
        //private DataContext db = new DataContext();

        private IUnitOfWorkData db;

        public AdministrationController()
        {
            this.db = new UnitOfWorkData();
        }

        // GET: /Administrator/Administration/
        public ActionResult Index()
        {
            return View(db.Tweets.All().ToList());
        }

        // GET: /Administrator/Administration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById((int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: /Administrator/Administration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/Administration/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SendTweetModel tweetModel)
        {
            Tweet tweet = new Tweet();

            if (ModelState.IsValid)
            {
                tweet.Content = tweetModel.Content;
                tweet.Creator = this.db.Users.All().FirstOrDefault(usr => usr.UserName == HttpContext.User.Identity.Name);

                HashSet<Tag> tags = this.CreateOrUpdateTags(tweetModel.Tags);

                foreach (var tag in tags)
                {
                    tweet.Tags.Add(tag);
                }

                db.Tweets.Add(tweet);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: /Administrator/Administration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById((int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            SendTweetModel model = new SendTweetModel();
            model.Content = tweet.Content;
            model.Id = tweet.Id;
            model.Tags = string.Join(" ", tweet.Tags.Select(t => "#" + t.Title).ToArray());

            return View(model);
        }

        // POST: /Administrator/Administration/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SendTweetModel model)
        {
            Tweet tweet = this.db.Tweets.All().FirstOrDefault(t => t.Id == model.Id);

            if (tweet != null && ModelState.IsValid)
            {
                tweet.Content = model.Content;

                HashSet<Tag> tags = this.CreateOrUpdateTags(model.Tags);
                tweet.Tags.Clear();

                foreach (var tag in tags)
                {
                    tweet.Tags.Add(tag);
                }

                this.db.Tweets.Update(tweet);
                //db.Entry(tweet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        // GET: /Administrator/Administration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById((int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Administrator/Administration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.GetById((int)id);
            db.Tweets.Delete(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private HashSet<Tag> CreateOrUpdateTags(string tagsString)
        {
            var tagsArray = tagsString.Split(new char[] { '#', }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<Tag> tagsSet = new HashSet<Tag>();

            var dbTags = this.db.Tags.All();

            foreach (var tagTitle in tagsArray)
            {
                var existingTag = dbTags.FirstOrDefault(t => t.Title.ToLower() == tagTitle.ToLower());

                if (existingTag == null)
                {
                    existingTag = new Tag() { Title = tagTitle.Trim() };
                }

                tagsSet.Add(existingTag);
            }

            return tagsSet;
        }
    }
}
