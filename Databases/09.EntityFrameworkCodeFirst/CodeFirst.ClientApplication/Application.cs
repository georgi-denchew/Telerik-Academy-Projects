using CodeFirst.Data;
using CodeFirst.Data.Migrations;
using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ClientApplication
{
    class Application
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <AcademyContext,Configuration>());

            var db = new AcademyContext();

            var homework = db.Homeworks.First(x => x.ID == 1);
            var course = new Course();
            course.Name = "PHP";
            course.Description = "Beginner's Course";
            course.Homeworks.Add(homework);
            course.Materials.Add("presentations");

            var student = new Student();
            student.Homeworks.Add(homework);
            student.FirstName = "Pesho";
            student.LastName = "Peshev";
            student.Number = 123456789;
            student.Courses.Add(course);
            db.Students.Add(student);

            course.Students.Add(student);

            db.SaveChanges();
        }
    }
}
