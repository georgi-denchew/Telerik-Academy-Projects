using BlogSystem.Data;
using BlogSystem.WebAPI.Attributes;
using BlogSystem.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace BlogSystem.WebAPI.Controllers
{
    public class TagsController : BaseApiController
    {
        public IQueryable<TagModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new BlogContext();

                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid user");
                    }

                    var tagsEntities = context.Tags;

                    var models =
                        from tag in tagsEntities
                        select new TagModel
                        {
                            Id = tag.Id,
                            Posts = tag.Posts.Count,
                            Name = tag.Name
                        };

                    return models.OrderBy(tag => tag.Name);
                });

            return responseMsg;
        }

        [ActionName("posts")]
        public IEnumerable<PostFullModel> GetPosts(int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new BlogContext();
                    
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid user");
                    }

                    var tagEntity = context.Tags.FirstOrDefault(tag => tag.Id == tagId);

                    var postEntities = tagEntity.Posts;

                    var models = GetPostModels(postEntities);

                    return models.OrderByDescending(post => post.PostDate);
                });

            return responseMsg;
        }

        private static IEnumerable<PostFullModel> GetPostModels(ICollection<BlogSystem.Models.Post> postEntities)
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
                             CommentedBy = c.CommentedBy,
                             PostDate = c.PostDate,
                             Text = c.Text
                         }),
                    Tags =
                        (from t in post.Tags
                         select t.Name)
                };
            return models;
        }
    }
}
