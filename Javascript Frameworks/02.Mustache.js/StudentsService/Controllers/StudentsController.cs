using StudentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsService.Controllers
{
    public class StudentsController : ApiController
    {
        private List<Student> students;

        public StudentsController()
        {
            this.GetStudents();
        }

        public IEnumerable<Student> Get()
        {
            return students;
        }

        [ActionName("marks")]
        public IEnumerable<Mark> GetMarksByStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(
                st => st.FirstName.ToLower() == firstName.ToLower() &&
                    st.LastName.ToLower() == lastName.ToLower());

            return student.Marks;
        }

        private void GetStudents()
        {
            var doncho = new Student() { Age = 10, FirstName = "Doncho", LastName = "Minkov", Grade = 5 };
            doncho.Marks.Add(new Mark() { Subject = "Math", Score = 4 });
            doncho.Marks.Add(new Mark() { Subject = "Javascript", Score = 6 });

            var niki = new Student() { Age = 12, FirstName = "Nikolay", LastName = "Kostov", Grade = 6 };
            niki.Marks.Add(new Mark() { Subject = "MVC", Score = 5 });
            niki.Marks.Add(new Mark() { Subject = "Javascript", Score = 6 });

            var joro = new Student() { Age = 16, FirstName = "Georgi", LastName = "Georgiev", Grade = 9 };
            joro.Marks.Add(new Mark() { Subject = "C#", Score = 5 });
            joro.Marks.Add(new Mark() { Subject = "Math", Score = 6 });

            var ivo = new Student() { Age = 15, FirstName = "Ivaylo", LastName = "Kenov", Grade = 9 };
            ivo.Marks.Add(new Mark() { Subject = "Java", Score = 5 });
            ivo.Marks.Add(new Mark() { Subject = "Javascript", Score = 6 });

            var nakov = new Student() { Age = 19, FirstName = "Svetlin", LastName = "Nakov", Grade = 10 };
            nakov.Marks.Add(new Mark() { Subject = "C#", Score = 5 });
            nakov.Marks.Add(new Mark() { Subject = "Java", Score = 6 });

            var asya = new Student() { Age = 12, FirstName = "Asya", LastName = "Georgieva", Grade = 6 };

            if (students == null)
            {
                students = new List<Student>();
            }

            students.Add(doncho);
            students.Add(niki);
            students.Add(joro);
            students.Add(ivo);
            students.Add(nakov);
            students.Add(asya);
        }

    }
}
