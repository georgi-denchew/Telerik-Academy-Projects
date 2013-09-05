using StudentsDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Runtime.Serialization;

namespace StudentsDb.WebAPI.Models
{
    [DataContract]
    public class StudentModel
    {
        public int ID { get; set; }

        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        [DataMember(Name="lastName")]
        public string LastName { get; set; }

        [DataMember(Name="age")]
        public int Age { get; set; }

        [DataMember(Name="grade")]
        public int Grade { get; set; }

        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return x => new StudentModel
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Grade = x.Grade,
                    Age = x.Age
                };
            }
        }

        public static StudentModel CreateModel(Student student)
        {
            return new StudentModel
            {
                Age = student.Age,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                ID = student.ID
            };
        }

        public Student CreateStudent()
        {
            return new Student
            {
                ID = this.ID,
                Grade = this.Grade,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Age = this.Age
            };
        }
    }
}