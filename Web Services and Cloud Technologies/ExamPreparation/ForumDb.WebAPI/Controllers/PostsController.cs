using ForumDb.Data;
using ForumDb.Models;
using ForumDb.WebAPI.Models;
using MyProject.Infrastructure.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace ForumDb.WebAPI.Controllers
{
    public class PostsController : BaseApiController
    {
        public IQueryable<PostModel> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new ForumContext();

                    var postsEntities = context.Posts;

                    var models =
                        from post in postsEntities
                        select new PostModel
                        {
                            Content = post.Content,
                            PostDate = post.PostDate,
                            PostedBy = post.User.Nickname,

                        };

                    return models;
                });

            return responseMsg;
        }

        public IQueryable<PostModel> Get(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey);

            var result = models.Skip(page * count).Take(count);

            return result;
        }

        [ActionName("vote")]
        public HttpResponseMessage AddVote(int postId, [FromBody]int value,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new ForumContext();

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid user");
                    }

                    var postEntity = context.Posts.FirstOrDefault(post => post.Id == postId);

                    if (postEntity == null)
                    {
                        throw new InvalidOperationException("Invalid post");
                    }

                    var voteEntity = new Vote()
                    {
                        Value = value,
                        Post = postEntity,
                        User = user
                    };

                    context.Votes.Add(voteEntity);
                    context.SaveChanges();

                    var voteModel = new VoteModel()
                    {
                        Value = voteEntity.Value,
                        CreatedBy = voteEntity.User.Nickname
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, voteModel);

                    return response;
                });

            return responseMsg;
        }

        [ActionName("comment")]
        [HttpPost]
        public HttpResponseMessage AddComment(int postId, [FromBody]string content,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new ForumContext();

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid user");
                    }

                    var postEntity = context.Posts.FirstOrDefault(post => post.Id == postId);

                    if (postEntity == null)
                    {
                        throw new InvalidOperationException("Invalid post");
                    }

                    var comment = new Comment()
                    {
                        CommentDate = DateTime.Now,
                        Content = content,
                        Post = postEntity,
                        User = user
                    };

                    var commentModel = new CommentModel()
                    {
                        CommentDate = comment.CommentDate,
                        Content = comment.Content,
                        CreatedBy = user.Nickname
                    };

                    postEntity.Comments.Add(comment);
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, commentModel);

                    return response;
                });

            return responseMsg;
        }
    }
}
