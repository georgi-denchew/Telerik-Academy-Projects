using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Application.ViewModels;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Application.Controllers
{
    public class TweetsController : Controller
    {
        IUnitOfWorkData db;

        public TweetsController()
        {
            this.db = new UnitOfWorkData();
        }

        public ActionResult Index()
        {
            return RedirectToAction("MyTweets");
        }

        public ActionResult MyTweets()
        {
            var user = this.db.Users.All().FirstOrDefault(usr => usr.UserName == HttpContext.User.Identity.Name);
            var tweets = user.Tweets;
            return View(tweets);
        }

        public ActionResult TweetsByTag(string tag)
        {
            var tags = this.db.Tags.All().ToList();
            var resultTag = tags.FirstOrDefault(t => t.Title.ToLower() == tag.ToLower());

            if (resultTag == null)
            {
                return PartialView("_TweetsList", new List<Tweet>());
            }

            return PartialView("_TweetsList", resultTag.Tweets);
        }

        public ActionResult Add()
        {
            return View();
        }

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

                return RedirectToAction("MyTweets");
            }

            return View(tweet);
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