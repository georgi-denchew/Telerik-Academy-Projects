using StudentsDb.Data;
using StudentsDb.Models;
using StudentsDb.Repositories;
using StudentsDb.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsDb.WebAPI.Controllers
{
    public class SchoolsController : ApiController
    {
        private EfRepository<School> schoolsRepository;
        private EfRepository<Student> studentsRepository;
        public SchoolsController()
        {
            this.schoolsRepository = new EfRepository<School>(new StudentsDbContext());
            this.studentsRepository = new EfRepository<Student>(new StudentsDbContext());
        }

        public SchoolsController(EfRepository<School> schoolsRepository)
        {
            this.schoolsRepository = schoolsRepository;
        }

        public IEnumerable<SchoolModel> GetAll()
        {
            return this.schoolsRepository.All()
                .Select(SchoolModel.FromSchool).ToList();
        }

        public SchoolFullModel Get(int Id)
        {
            var school = this.schoolsRepository.Get(Id);

            SchoolFullModel resultSchool = SchoolFullModel.CreateFullModel(school);

            return resultSchool;
        }

        public HttpResponseMessage Post([FromBody]SchoolFullModel schoolModel)
        {
            var school = schoolModel.CreateSchool();
            this.schoolsRepository.Add(school);

            foreach (var item in schoolModel.Students)
            {
                var student = item.CreateStudent();
                this.studentsRepository.Add(student);
            }

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + school.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }
    }
}
