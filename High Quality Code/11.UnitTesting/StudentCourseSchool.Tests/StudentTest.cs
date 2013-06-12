using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_03.UnitTesting;

namespace StudentCourseSchool.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestCreatingStudentWithInvalidSchoolNumber()
        {
            Student pesho = new Student("pesho", 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestCreatingStudentWithInvalidName()
        {
            Student noName = new Student(null, 12345);
        }
    }
}
