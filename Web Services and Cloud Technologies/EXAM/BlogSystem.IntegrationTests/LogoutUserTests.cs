using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Collections.Generic;
using System.Web.Http;
using BlogSystem.WebAPI.Models;
using System.Net;

namespace BlogSystem.IntegrationTests
{
    [TestClass]
    public class LogoutUserTests
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
    }
}
