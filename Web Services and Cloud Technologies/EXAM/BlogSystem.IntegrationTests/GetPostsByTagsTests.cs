using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Transactions;
using System.Collections.Generic;
using BlogSystem.WebAPI.Models;
using Newtonsoft.Json;
using System.Net;

namespace BlogSystem.IntegrationTests
{
    [TestClass]
    public class GetPostsByTagsTests
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
        public void GetSinglePost()
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

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            
            httpServer.Post("api/posts", postModel, headers);
            var response = httpServer.Get("api/posts?tags=tag1,tag2", headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var models = JsonConvert.DeserializeObject<List<PostFullModel>>(contentString);
            var modelsExpectedCount = 1;
            
            Assert.AreEqual(models.Count, modelsExpectedCount);
            Assert.AreEqual(models[0].Title, postModel.Title);
        }

        [TestMethod]
        public void GetMultiplePostsTwoTags_ShouldReturn200()
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

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            httpServer.Post("api/posts", postModel, headers);
            httpServer.Post("api/posts", postModel, headers);

            var response = httpServer.Get("api/posts?tags=tag1,tag2", headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var models = JsonConvert.DeserializeObject<List<PostFullModel>>(contentString);
            var modelsCount = 2;

            Assert.AreEqual(modelsCount, models.Count);
        }

        [TestMethod]
        public void GetMultiplePostsOneTag()
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

            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            httpServer.Post("api/posts", postModel, headers);
            httpServer.Post("api/posts", postModel, headers);

            var response = httpServer.Get("api/posts?tags=tag1", headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var models = JsonConvert.DeserializeObject<List<PostFullModel>>(contentString);
            var modelsCount = 2;

            Assert.AreEqual(modelsCount, models.Count);
        }

        [TestMethod]
        public void GetNoPosts()
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

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;

            var response = httpServer.Get("api/posts?tags=tag1,tag2", headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var models = JsonConvert.DeserializeObject<List<PostFullModel>>(contentString);
            var modelsCount = 0;

            Assert.AreEqual(modelsCount, models.Count);
        }
    }
}
