using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{

    /// <summary>
    /// I HAD NO TIME TO FINISH --> I WOULD HAVE COMPLETED IT
    /// </summary>

    public class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name)
            : this(name, null, null)
        {
        }

        public Course(string name, string teacherName)
            : this(name, teacherName, null)
        {
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.students = students;
        }

        public IList<string> Students
        {
            get 
            { 
                return this.students; 
            }

            protected set 
            {
                this.students = value; 
            }
        }

        public string TeacherName
        {
            get 
            { 
                return this.teacherName; 
            }

            protected set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value for teacher name cannot be null or an empty string");
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Value for teacher name cannot be null or white space");
                }

                this.teacherName = value; 
            }
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            protected set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value for name cannot be null or an empty string");
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Value for name cannot be null or white space");
                }

                this.name = value; 
            }
        }

        public void AddStudent(string student)
        {
            this.Students.Add(student);
        }

        public void AnnounceStudents(List<string> students)
        {
            this.Students = students;
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "NO STUDENTS IN THIS COURSE";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = ");
            AppendNameTeacherAndStudents();
            result.Append(" }");
            return result.ToString();
        }

        /// <summary>
        /// This method extracts the common functionality of
        /// the ToString() method of LocalCourse, OffsiteCourse and Course
        /// </summary>
        /// <returns></returns>
        protected string AppendNameTeacherAndStudents()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name);
            
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }
    }
}
