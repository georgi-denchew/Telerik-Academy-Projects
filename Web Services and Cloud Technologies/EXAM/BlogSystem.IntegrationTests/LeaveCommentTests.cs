using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Collections.Generic;
using System.Web.Http;
using BlogSystem.WebAPI.Models;
using Newtonsoft.Json;
using System.Net;

namespace BlogSystem.IntegrationTests
{
    [TestClass]
    public class LeaveCommentTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
            List<Route> routes = new List<Route>
            {
                new Route(
                 "GetPostsByTagId",
                "api/tags/{tagId}/{action}",
                new
                {
                    controller = "tags",
                }
                ),

            new Route(
                "PostsAddVoteApi",
                "api/posts/{postId}/{action}",
                new
                {
                    controller = "posts",
                }
                ),

            new Route(
                "UsersApi",
                "api/users/{action}",
                new
                {
                    controller = "users"
                }
                ),

            new Route(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            )
            };

            httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Create_ValidComment_ShouldReturn200()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var usernameResponse = httpServer.Post("api/users/register", testUser);
            var usernameContentString = usernameResponse.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(usernameContentString);
            Assert.AreEqual(HttpStatusCode.Created, usernameResponse.StatusCode);

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postResponse = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);
            Assert.IsNotNull(postResponse.Content);

            var postContentString = postResponse.Content.ReadAsStringAsync().Result;
            var postReceivedModel = JsonConvert.DeserializeObject<PostResponseModel>(postContentString);

            var commentModel = new CommentModel()
            {
                Text = "Hello, this is a new comment"
            };

            var commentResponse = httpServer.Put(string.Format("api/posts/{0}/comment", postReceivedModel.Id), commentModel, headers);

            Assert.AreEqual(HttpStatusCode.OK, commentResponse.StatusCode);
        }

        [TestMethod]
        public void Create_InvalidComment_InvalidUsername_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var usernameResponse = httpServer.Post("api/users/register", testUser);
            var usernameContentString = usernameResponse.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(usernameContentString);
            Assert.AreEqual(HttpStatusCode.Created, usernameResponse.StatusCode);

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = "somesessionkey";
            var postResponse = httpServer.Post("api/posts", postModel, headers);

            var postContentString = postResponse.Content.ReadAsStringAsync().Result;
            var postReceivedModel = JsonConvert.DeserializeObject<PostResponseModel>(postContentString);

            var commentModel = new CommentModel()
            {
                Text = "Hello, this is a new comment"
            };

            var commentResponse = httpServer.Put(string.Format("api/posts/{0}/comment", postReceivedModel.Id), commentModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, commentResponse.StatusCode);
        }

        [TestMethod]
        public void Create_InvalidComment_InvalidPost_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var usernameResponse = httpServer.Post("api/users/register", testUser);
            var usernameContentString = usernameResponse.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(usernameContentString);
            Assert.AreEqual(HttpStatusCode.Created, usernameResponse.StatusCode);

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = "somesessionkey";
            var postResponse = httpServer.Post("api/posts", postModel, headers);

            var postContentString = postResponse.Content.ReadAsStringAsync().Result;
            var postReceivedModel = JsonConvert.DeserializeObject<PostResponseModel>(postContentString);

            var commentModel = new CommentModel()
            {
                Text = "Hello, this is a new comment"
            };

            var commentResponse = httpServer.Put(string.Format("api/posts/{0}/comment", postReceivedModel.Id), commentModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, commentResponse.StatusCode);
        }

        [TestMethod]
        public void Create_InvalidComment_InvalidTextLength_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var usernameResponse = httpServer.Post("api/users/register", testUser);
            var usernameContentString = usernameResponse.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(usernameContentString);
            Assert.AreEqual(HttpStatusCode.Created, usernameResponse.StatusCode);

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = "somesessionkey";
            var postResponse = httpServer.Post("api/posts", postModel, headers);

            var postContentString = postResponse.Content.ReadAsStringAsync().Result;
            var postReceivedModel = JsonConvert.DeserializeObject<PostResponseModel>(postContentString);

            var commentModel = new CommentModel()
            {
                Text = "H"
            };

            var commentResponse = httpServer.Put(string.Format("api/posts/{0}/comment", postReceivedModel.Id), commentModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, commentResponse.StatusCode);
        }
    }
}
