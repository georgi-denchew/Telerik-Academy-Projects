namespace _01_03.UnitTesting
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private string name;
        private IList<Student> students;

        public School(string name, List<Student> students = null)
        {
            this.Name = name;
            this.Students = students;
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;
            }

            protected set
            {
                if (value == null)
                {
                    this.students = new List<Student>();
                }
                else
                {
                    this.students = value;
                }
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
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("School name cannot be null or an empty string");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            try
            {
                foreach (Student st in this.Students)
                {
                    if (st.SchoolNumber == student.SchoolNumber)
                    {
                        throw new InvalidOperationException();
                    }
                }

                this.Students.Add(student);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("School {0} already has a student with the number {1}", this.name, student.SchoolNumber);
            }
        }
    }
}
