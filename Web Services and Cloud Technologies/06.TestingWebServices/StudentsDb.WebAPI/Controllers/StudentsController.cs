using StudentsDb.Repositories;
using StudentsDb.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;
using StudentsDb.Models;
using StudentsDb.Data;

namespace StudentsDb.WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> studentsRepository;

        public StudentsController()
        {
            this.studentsRepository = new EfRepository<Student>(new StudentsDbContext());
        }

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public IQueryable<StudentFullModel> GetAll()
        {
            var result =
                from st in this.studentsRepository.All()
                select new StudentFullModel
                {
                    Age = st.Age,
                    FirstName = st.FirstName,
                    Grade = st.Grade,
                    LastName = st.LastName,
                    Marks =
                        from m in st.Marks
                        select new MarkModel
                        {
                            Subject = m.Subject,
                            Value = m.Value
                        }
                };
            return result;
        }

        public StudentModel Get(int Id)
        {
            var student = this.studentsRepository.Get(Id);

            StudentModel resultStudent = StudentModel.CreateModel(student);

            return resultStudent;
        }

        public IQueryable<StudentFullModel> Get(string subject, double value)
        {
            var allStudents = this.GetAll();
            var result = allStudents.Where(x => x.Marks.Any(y => y.Value >= value && y.Subject == subject));
            return result;
        }

        public HttpResponseMessage Post(Student studentModel)
        {
            var student = studentModel;
            this.studentsRepository.Add(student);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + student.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public HttpResponseMessage Put(int id, Student student)
        {
            var updated = this.studentsRepository.Update(id, student);

            var response =
                this.Request.CreateResponse(HttpStatusCode.Created, student);
            response.Headers.Location = new Uri(Url.Link("DefaultApi",
                new { id = student.ID }));

            return response;
        }

        public void Delete(int Id)
        {
            this.studentsRepository.Delete(Id);
        }
    }
}
