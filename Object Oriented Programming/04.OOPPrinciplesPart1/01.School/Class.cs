using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Class
    {
        private string identifier;
        private List<Teacher> teachers;
        private List<Student> students;
        
        public Class(string identifier, List<Teacher> teachers, List<Student> students)
        {
            this.identifier = identifier;
            this.teachers = teachers;
            this.students = students;
        }

        public string Identifier
        {
            get { return this.identifier; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        public List<Student> Students
        {
            get { return this.students; }
        }
    }
}
