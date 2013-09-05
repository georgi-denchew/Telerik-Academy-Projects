using Forum.DataLayer;
using Forum.Models;
using Forum.WebAPI.Attributes;
using Forum.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace Forum.WebAPI.Controllers
{
    public class PostsController : BaseApiController
    {
        private const int TextMinLength = 10;
        private const int TitleMinLength = 6;
        private const int TagNameMinLength = 2;
        private const int CommentMinLength = 2;
        private static char[] SplitSymbols = new char[] { ' ', ',', '!', '.', '-', '?', '\'' };

        [HttpPost]
        public HttpResponseMessage Create([FromBody]PostModel postModel, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid user");
                }

                if (postModel.Text == null || postModel.Text == string.Empty)
                {
                    throw new ArgumentException(
                        string.Format("Post text should be at least {0} characters long", TextMinLength));
                }

                if (postModel.Title == null || postModel.Title.Length < TitleMinLength)
                {
                    throw new ArgumentException(
                        string.Format("Post title should be at least {0} characters long", TitleMinLength));
                }

                var postEntity = GeneratePostEntity(postModel, context, user);

                context.Posts.Add(postEntity);
                context.SaveChanges();

                var resultPostModel = new PostResponseModel()
                {
                    Id = postEntity.Id,
                    Title = postEntity.Title
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, resultPostModel);

                return response;
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostFullModel> GetAll(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid user");
                }

                var postEntities = context.Posts;

                var models = GetPostModels(postEntities);

                return models.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }

        public HttpResponseMessage GetById (int id, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var existingPost = this.GetAll(sessionKey).FirstOrDefault(post => post.Id == id);

                if (existingPost == null)
                {
                    throw new ArgumentNullException("Invalid post");
                }

                var response = this.Request.CreateResponse(HttpStatusCode.OK, existingPost);

                return response;
            });

            return responseMsg;
        }

        public IEnumerable<PostFullModel> GetByTags(string tags, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var allTags = tags.Split(',');

                var models = this.GetAll(sessionKey);

                var result = models.ToList().Where(post => post.Tags.Intersect(allTags).Count() == allTags.Length);

                return result.OrderByDescending(post => post.PostDate);
            });

            return responseMsg;
        }

        [ActionName("comment")]
        [HttpPut]
        public HttpResponseMessage AddComment(int postId, [FromBody]CommentModel commentModel, string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("Invalid user");
                }

                var postEntity = context.Posts.FirstOrDefault(post => post.Id == postId);

                if (postEntity == null)
                {
                    throw new InvalidOperationException("Post does not exist");
                }

                if (commentModel.Text.Trim().Length < CommentMinLength)
                {
                    throw new ArgumentException(
                        string.Format("Comment text should be at least {0} characters long", CommentMinLength));
                }

                var comment = new Comment()
                {
                    PostedBy = user.Nickname,
                    PostDate = DateTime.Now,
                    Text = commentModel.Text,
                    User = user
                };

                postEntity.Comments.Add(comment);
                context.SaveChanges();

                var response = this.Request.CreateResponse(HttpStatusCode.OK);

                return response;
            });

            return responseMsg;
        }

        private static IQueryable<PostFullModel> GetPostModels(System.Data.Entity.DbSet<Post> postEntities)
        {
            var models =
                from post in postEntities
                select new PostFullModel
                {
                    Id = post.Id,
                    PostDate = post.PostDate,
                    PostedBy = post.PostedBy,
                    Text = post.Text,
                    Title = post.Title,
                    Comments =
                        (from c in post.Comments
                         select new CommentModel
                         {
                             PostedBy = c.PostedBy,
                             PostDate = c.PostDate,
                             Text = c.Text
                         }),
                    Tags =
                        (from t in post.Tags
                         select t.Name)
                };
            return models;
        }

        private static Post GeneratePostEntity(PostModel postModel, ForumDbContext context, Forum.Models.User user)
        {
            var postEntity = new Post()
            {
                Title = postModel.Title,
                Text = postModel.Text,
                User = user,
                PostedBy = user.Nickname,
                PostDate = DateTime.Now
            };

            foreach (var tagName in postModel.Tags)
            {
                if (tagName.Length < TagNameMinLength || tagName == null)
                {
                    throw new ArgumentException(
                        string.Format("Tag name should be at least {0} characters long", TagNameMinLength));
                }
                var tagNameToLower = tagName.ToLower();

                var existingTag = postEntity.Tags.FirstOrDefault(tag => tag.Name == tagNameToLower);

                if (existingTag == null)
                {
                    existingTag = context.Tags.FirstOrDefault(tag => tag.Name == tagNameToLower);

                    if (existingTag == null)
                    {
                        existingTag = new Tag()
                        {
                            Name = tagNameToLower
                        };
                    }
                }

                postEntity.Tags.Add(existingTag);
            }

            foreach (var word in postModel.Title.Split(SplitSymbols, StringSplitOptions.RemoveEmptyEntries))
            {
                if (word.Length < TagNameMinLength)
                {
                    continue;
                }

                var tagNameToLower = word.ToLower();

                var existingTag = postEntity.Tags.FirstOrDefault(tag => tag.Name == tagNameToLower);

                if (existingTag == null)
                {
                    existingTag = context.Tags.FirstOrDefault(tag => tag.Name == tagNameToLower);

                    if (existingTag == null)
                    {
                        existingTag = new Tag()
                        {
                            Name = tagNameToLower
                        };
                    }
                }

                postEntity.Tags.Add(existingTag);
            }
            return postEntity;
        }
    }
}