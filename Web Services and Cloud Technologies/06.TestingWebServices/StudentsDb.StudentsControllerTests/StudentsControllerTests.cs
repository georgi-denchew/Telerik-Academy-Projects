using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using StudentsDb.Models;
using StudentsDb.Repositories;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock.Expectations.Abstraction;
using StudentsDb.WebAPI.Controllers;

namespace StudentsDb.StudentsControllerTests
{
    [TestClass]
    public class StudentsControllerTests
    {
        [TestMethod]
        public void TestAdd()
        {
            bool isAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var student = new Student()
            {
                ID = 1,
                FirstName = "pesho",
                LastName = "peshev",
                Grade = 10
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isAdded = true).Returns(student);

            var controller = new StudentsController(repository);
            SetupController.Create(controller, "post", "student");

            var result = controller.Post(student);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void TestGetAllStudents()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var student = new Student()
            {
                ID = 1,
                FirstName = "pesho",
                LastName = "peshev",
                Grade = 10
            };

            var secondStudent = new Student()
            {
                ID = 2,
                FirstName = "gosho",
                LastName = "goshev",
                Grade = 1
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(student);
            studentEntities.Add(secondStudent);

            Mock.Arrange(() => repository.All()).Returns(() => studentEntities.AsQueryable());

            var controller = new StudentsController(repository);

            var allStudents = controller.GetAll();

            Assert.IsTrue(allStudents.Count() == 2);
            
        }

        [TestMethod]
        public void TestGetStudentByID()
        {
            var repository = Mock.Create<IRepository<Student>>();

            var student = new Student()
            {
                ID = 1,
                FirstName = "pesho",
                LastName = "peshev",
                Grade = 10
            };

            Mock.Arrange<Student>(() => repository.Get(student.ID))
                .IgnoreArguments()
                .Returns(student)
                .MustBeCalled();

            var controller = new StudentsController(repository);
            SetupController.Create(controller, "get", "student");
            var result = controller.Get(student.ID);
            Assert.AreEqual(result.ID, student.ID);
            Assert.AreEqual(result.FirstName, student.FirstName);
            Assert.AreEqual(result.LastName, student.LastName);
            Assert.AreEqual(result.Grade, student.Grade);
        }

        [TestMethod]
        public void TestUpdateStudent()
        {
            bool isAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var student = new Student()
            {
                ID = 1,
                FirstName = "pesho",
                LastName = "peshev",
                Grade = 10
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isAdded = true)
                .Returns(student);

            var controller = new StudentsController(repository);
            SetupController.Create(controller, "post", "student");

            bool isItemUpdated = false;

            var studentToUpdate = new Student()
            {
                ID = 1,
                FirstName = "gosho",
                LastName = "goshev",
                Grade = 1
            };

            Mock.Arrange<Student>(() => repository.Update(studentToUpdate.ID, studentToUpdate))
                .DoInstead(() => isItemUpdated = true)
                .Returns(studentToUpdate);

            SetupController.Create(controller, "put", "student");

            var result = controller.Put(studentToUpdate.ID, studentToUpdate);

            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(isItemUpdated);
        }

        [TestMethod]
        public void TestDeleteStudent()
        {
            bool isAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var student = new Student()
            {
                ID = 1,
                FirstName = "pesho",
                LastName = "peshev",
                Grade = 10
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isAdded = true)
                .Returns(student);

            var controller = new StudentsController(repository);
            SetupController.Create(controller, "post", "student");

            bool isItemDeleted = false;

            controller.Post(student);

            Mock.Arrange(() => repository.Delete(Arg.IsAny<Student>()))
                .DoInstead(() => isItemDeleted = true);

            SetupController.Create(controller, "delete", "student");

            controller.Delete(student.ID);

            Assert.IsTrue(isItemDeleted);
        }
    }
}
