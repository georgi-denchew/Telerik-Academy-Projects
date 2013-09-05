using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSystem.WebAPI.Models;
using System.Net;
using Newtonsoft.Json;
using System.Transactions;
using System.Collections.Generic;
using System.Web.Http;

namespace BlogSystem.IntegrationTests
{
    [TestClass]
    public class UnitTest1
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
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            int expectedSessionKeyLength = 50;
            Assert.AreEqual(expectedSessionKeyLength, model.SessionKey.Length);
        }

        [TestMethod]
        public void Register_WhenUserModelWithValidSymbols_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser1234_.",
                DisplayName = "validnick1234_ -.",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            int expectedSessionKeyLength = 50;
            Assert.AreEqual(expectedSessionKeyLength, model.SessionKey.Length);
        }

        [TestMethod]
        public void Register_ExistingUsername_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);
            
            var existingUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "newnick123",
                AuthCode = new string('b', 40)
            };

            var secondResponse = httpServer.Post("api/users/register", existingUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, secondResponse.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Register_ExistingDisplayName_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            var existingUser = new UserModel()
            {
                Username = "NewUsername",
                DisplayName = "validnick",
                AuthCode = new string('b', 40)
            };

            var secondResponse = httpServer.Post("api/users/register", existingUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, secondResponse.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Register_InvalidDisplayName_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "invalidnick%^*^%*&",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Register_InvalidShortDisplayName_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "ValidUser",
                DisplayName = "i",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Register_InvalidShortUsername_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "i",
                DisplayName = "validnickname",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Register_InvalidUsername_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "afgfdfh*&(",
                DisplayName = "validnickname",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Register_InvalidAuthCode_ShouldReturnBadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "afgfdfh*&(",
                DisplayName = "validnickname",
                AuthCode = new string('b', 15)
            };

            var response = httpServer.Post("api/users/register", testUser);


            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
