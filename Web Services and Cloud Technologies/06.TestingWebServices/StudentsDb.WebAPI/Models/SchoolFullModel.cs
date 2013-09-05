using StudentsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsDb.WebAPI.Models
{
    public class SchoolFullModel : SchoolModel
    {
        public SchoolFullModel()
        {
            this.Students = new HashSet<StudentModel>();
        }
        public ICollection<StudentModel> Students { get; set; }

        public static SchoolFullModel CreateFullModel(School school)
        {
            SchoolFullModel result = new SchoolFullModel
            {
                Name = school.Name,
                ID = school.ID,
                Location = school.Location
            };

            foreach (Student student in school.Students)
            {
                result.Students.Add(StudentModel.CreateModel(student));
            }

            return result;
        }
    }
}