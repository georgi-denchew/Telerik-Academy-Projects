using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Data;
using StudentsDb.Models;
using System.Transactions;
using System.Collections;
using System.Linq;


namespace StudentsDb.Repositories.Tests
{
    [TestClass]
    public class DbStudentsRepositoryTests
    {
        public StudentsDbContext dbContext { get; set; }

        static Random rand = new Random();

        public EfRepository<Student> studentsRepository { get; set; }

        private static TransactionScope tranScope { get; set; }

        public DbStudentsRepositoryTests()
        {
            this.dbContext = new StudentsDbContext();
            this.studentsRepository = new EfRepository<Student>(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }


        [TestMethod]
        public void TestAdding()
        {
            var student = new Student()
            {
                Age = 1,
                FirstName = "pesho",
                LastName = "obama",
                Grade = 4
            };

            this.studentsRepository.Add(student);
            Assert.IsTrue(student.ID > 0);
        }

        [TestMethod]
        public void TestFindingAddedStudent()
        {
            var student = new Student()
            {
                Age = 1,
                FirstName = "pesho",
                LastName = "obama",
                Grade = 4
            };

            this.studentsRepository.Add(student);

            var found = this.studentsRepository.Get(student.ID);

            Assert.IsNotNull(found);
        }

        [TestMethod]
        public void TestAllCount()
        {
            var student = new Student()
            {
                Age = 1,
                FirstName = "pesho",
                LastName = "obama",
                Grade = 4
            };

            var secondStudent = new Student()
            {
                Age = 1,
                FirstName = "gosho",
                LastName = "obama",
                Grade = 4
            };


            this.studentsRepository.Add(student);
            this.studentsRepository.Add(secondStudent);
            IQueryable<Student> all = this.studentsRepository.All();
            int actual = all.Count();
            int expected = 2;

            Assert.IsTrue(actual >= expected);
        }

        [TestMethod]

        public void TestUpdate()
        {
            var student = new Student()
            {
                Age = 1,
                FirstName = "pesho",
                LastName = "obama",
                Grade = 4
            };

            this.studentsRepository.Add(student);

            student.FirstName = "gosho";
            this.studentsRepository.Update(student.ID, student);

            var updated = this.studentsRepository.Get(student.ID);
            var actual = updated.FirstName;
            var expected = "gosho";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDelete()
        {
            var initialCount = this.studentsRepository.DbSet.Count();

            var student = new Student()
            {
                Age = 1,
                FirstName = "pesho",
                LastName = "obama",
                Grade = 4
            };

            this.studentsRepository.Add(student);

            var beforeDeleteCount = this.studentsRepository.DbSet.Count();

            this.studentsRepository.Delete(student.ID);

            var afterDeleteCount = this.studentsRepository.DbSet.Count();

            Assert.AreEqual(initialCount, afterDeleteCount);
            Assert.IsTrue(beforeDeleteCount > initialCount);
        }
    }
}
