using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using ForumDb.WebAPI.Models;
using System.Net;
using Newtonsoft.Json;

namespace Forum.Tests
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;
        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }
        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }
        [TestMethod]
        public void GetAll_WhenDataInDatabase_ShouldReturnData()
        {
            var httpServer = new InMemoryHttpServer("http://localhost/");

            httpServer.CreateGetRequest("api/threads");
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
               {
                   Username = "ValidUser",
                   Nickname = "validnick",
                   AuthCode = new string('b', 40)
               };

            var httpServer = new InMemoryHttpServer("http://localhost/");
            var response = httpServer.CreatePostRequest("api/users/register", testUser);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);

        }
    }
}
