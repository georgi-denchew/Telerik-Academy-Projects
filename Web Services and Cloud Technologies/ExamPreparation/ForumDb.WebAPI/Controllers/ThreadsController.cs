using ForumDb.Data;
using ForumDb.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.ValueProviders;
using MyProject.Infrastructure.WebAPI;
using ForumDb.Models;
using System.Data.Entity.Infrastructure;
using System.Text;



namespace ForumDb.WebAPI.Controllers
{
    public class ThreadsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<ThreadModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new ForumContext();

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    var threadEntities = context.Threads;
                    var models = (from thr in threadEntities
                                  select new ThreadModel
                                  {
                                      Id = thr.Id,
                                      Title = thr.Title,
                                      DateCreated = thr.DateCreated,
                                      Content = thr.Content,
                                      CreatedBy = thr.User.Nickname,
                                      Categories =
                                          from cat in thr.Categories
                                          select cat.Name,
                                      Posts =
                                          (from post in thr.Posts
                                           select new PostModel
                                           {
                                               Content = post.Content,
                                               PostDate = post.PostDate,
                                               PostedBy = post.User.Nickname
                                           }),
                                  });

                    return models.OrderByDescending(x => x.DateCreated);

                });

            return responseMsg;
        }

        public IQueryable<ThreadModel> GetPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);

            return models;
        }

        public IQueryable<ThreadModel> GetByCategory(string category,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey).Where(thr => thr.Categories.Any(cat => cat == category));

            return models;
        }

        [ActionName("posts")]
        public IQueryable<PostModel> GetPost(int threadId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new ForumContext();

                    var postEntities = context.Threads.FirstOrDefault(thr => thr.Id == threadId).Posts;

                    PostModel[] models =
                    { 
                        new PostModel()
                    {
                        Content = "First",
                        PostDate = DateTime.Now,
                        PostedBy = "asd",
                        Rating = "5/5"
                    }};

                    return models.AsQueryable();
                });

            return responseMsg;
        }

        [ActionName("create")]
        [HttpPost]
        public HttpResponseMessage Create(ThreadModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new ForumContext();
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                    Thread thread = new Thread()
                    {
                        Content = model.Content,
                        DateCreated = model.DateCreated,
                        Title = model.Title
                    };

                    context.Threads.Add(thread);
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, thread);

                    return response;
                });

            return responseMsg;
        }


        private static IQueryable<ThreadModel> GetThreadModels(IQueryable<ForumDb.Models.Thread> threadEntities)
        {
            var models =
                (from thr in threadEntities
                 select new ThreadModel
                 {
                     Id = thr.Id,
                     Title = thr.Title,
                     DateCreated = thr.DateCreated,
                     Content = thr.Content,
                     CreatedBy = thr.User.Nickname,
                     Categories =
                         from cat in thr.Categories
                         select cat.Name,
                     Posts =
                         (from post in thr.Posts
                          select new PostModel
                          {
                              Content = post.Content,
                              PostDate = post.PostDate,
                              PostedBy = post.User.Nickname
                          }),
                 });
            return models;
        }
    }
}
