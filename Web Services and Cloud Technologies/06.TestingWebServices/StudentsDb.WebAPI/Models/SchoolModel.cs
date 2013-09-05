using StudentsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentsDb.WebAPI.Models
{
    public class SchoolModel
    {
        public int ID { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public static Expression<Func<School, SchoolModel>> FromSchool
        {
            get
            {
                return x => new SchoolModel
                {
                    ID = x.ID,
                    Location = x.Location,
                    Name = x.Name
                };
            }
        }

        public static SchoolModel CreateModel(School school)
        {
            return new SchoolModel
            {
                ID = school.ID,
                Location = school.Location,
                Name = school.Name
            };
        }

        public School CreateSchool()
        {
            return new School
            {
                ID = this.ID,
                Location = this.Location,
                Name = this.Name
            };
        }
    }
}