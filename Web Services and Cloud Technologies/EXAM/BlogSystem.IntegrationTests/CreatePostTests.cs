using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using BlogSystem.WebAPI.Models;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace BlogSystem.IntegrationTests
{
    [TestClass]
    public class CreatePostsTests
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
        public void Create_ValidPost_ShouldReturn200()
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
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
            Assert.AreEqual(postModel.Title, model.Title);
        }

        [TestMethod]
        public void Create_ValidPost_InvalidSessionKey_ShouldReturnBadRequest()
        {
            var postModel = new PostModel()
            {
                Tags = new string[] { "tag1", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = "asd";
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Create_InvalidPostTitle_ShouldReturnBadRequest()
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
                Title = "Hello"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
        }

        [TestMethod]
        public void Create_InvalidPostTag_ShouldReturnBadRequest()
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
                Tags = new string[] { "t", "tag2", "tag3" },
                Text = "The quick brown fox jumped over the lazy dog",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
        }

        [TestMethod]
        public void Create_InvalidPostText_ShouldReturnBadRequest()
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
                Tags = new string[] { "t", "tag2", "tag3" },
                Text = "The qui",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
        }

        [TestMethod]
        public void Create_NullPostText_ShouldReturnBadRequest()
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
                Tags = new string[] { "t", "tag2", "tag3" },
                Text = null,
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
        }

        [TestMethod]
        public void Create_NullPostTitle_ShouldReturnBadRequest()
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
                Tags = new string[] { "t", "tag2", "tag3" },
                Text = "The quick brown fox bla bla bla",
                Title = null
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
        }

        [TestMethod]
        public void Create_NullPostTag_ShouldReturnBadRequest()
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
                Tags = new string[] { null, "tag2", "tag3" },
                Text = "The quick brown fox bla bla bla",
                Title = "Hello, World!"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<PostResponseModel>(contentString);
        }
    }
}
