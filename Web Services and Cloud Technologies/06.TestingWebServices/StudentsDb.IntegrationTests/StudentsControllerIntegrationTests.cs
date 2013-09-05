using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using StudentsDb.Repositories;
using StudentsDb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using StudentsDb.WebAPI.Models;

namespace StudentsDb.IntegrationTests
{
    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestMethod]
        public void GetAll_ShouldReturnStatusCode200AndContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            
            models.Add(new Student()
            {
                FirstName = "pesho"
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
        [TestMethod]
        public void GetByID_WithValidID_ShouldReturnStatusCode200AndCorrectStudent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Student studentEntity = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
            };

            var studentEntities = new List<Student>();
            studentEntities.Add(studentEntity);

            int id = 1;
            id--;
            Mock.Arrange(() => mockRepository.Get(id))
                .Returns(() => id >= 0 ? studentEntities[id] : null);

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreateGetRequest("api/students/" + id);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void GetSingle_ShouldReturnStatusCode200AndContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var student = new Student()
            {
                FirstName = "gosho"
            };

            var studentEntites = new List<Student>();
            studentEntites.Add(student);

            int id = 1;
            id--;

            Mock.Arrange(() => mockRepository.Get(id))
                .Returns(() => id >= 0 ? studentEntites[id] : null);

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students/" + Arg.IsAny<int>());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void Post_ShouldReturnStatusCode201AndContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            
            var student = new Student() 
            {
                FirstName = "pesho"
            };

            Mock.Arrange(() => mockRepository.Add(Arg.IsAny<Student>()))
                .Returns(student);

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);
            var response = server.CreatePostRequest("api/students", student);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void StatusCode500()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository
                .Add(Arg.Matches<Student>(student => student.FirstName == null)))
                    .Throws<NullReferenceException>();

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/students",
                new Student()
                {
                    FirstName = null
                });

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
