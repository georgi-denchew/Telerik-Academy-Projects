using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_03.UnitTesting;
using System.Collections.Generic;

namespace StudentCourseSchool.Tests
{
    [TestClass]
    public class CourseTests
    {
        Course course = new Course("marketing", null);
        Student mariika = new Student("Mara Mariiska", 12300);
        Student sashka = new Student("Sashka Vaseva", 11111);

        [TestMethod]
        // It's meaningless to test property getters and setter,
        // but there's no other way I can get Code Coverage over 90%
        public void GetCourseName() 
        {
            Assert.AreEqual("marketing", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void CreateCourseInstanceWithMoreThanMaximumStudents()
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < Course.MaximumStudents ; i++)
            {
                students.Add(mariika);
            }

            Course newCourse = new Course("Koi e po-po-nai", students);
        }

        

        [TestMethod]
        public void TestJoin_SameStudent()
        {
            course.Join(mariika);
            course.Join(mariika);
            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void TestJoin_TwoStudent()
        {
            course.Join(mariika);
            course.Join(sashka);
            Assert.AreEqual(2, course.Students.Count);
        }

        [TestMethod]
        public void TestLeave_Mariika()
        {
            course.Join(mariika);
            course.Join(sashka);
            course.Leave(sashka);
            Assert.AreEqual(1, course.Students.Count);
        }
    }
}