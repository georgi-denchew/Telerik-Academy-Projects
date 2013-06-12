using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_03.UnitTesting;

namespace StudentCourseSchool.Tests
{
    [TestClass]
    public class SchoolTests
    {
        School school = new School("daskalo");
        Student pesho = new Student("pesho", 12345);
        Student gosho = new Student("gosho", 12333);
        Student secondPesho = new Student("Pesho Peshev", 12345);

        [TestMethod]
        public void GetSchoolName()
        {
            Assert.AreEqual("daskalo", school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreateSchoolInstanceWithInvalidName()
        {
            School highSchool = new School(null);
        }

        [TestMethod]
        public void TestAddStudent_AddFirstStudent()
        {
            school.AddStudent(pesho);
            
            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        public void TestAddStudent_AddSameNumberStudent()
        {
            school.AddStudent(pesho);
            school.AddStudent(secondPesho);

            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        public void TestAddStudent_AddTwoStudents()
        {
            school.AddStudent(pesho);
            school.AddStudent(gosho);

            Assert.AreEqual(2, school.Students.Count);
        }
    }
}
