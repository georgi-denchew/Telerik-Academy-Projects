namespace _01_03.UnitTesting
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public const int MaximumStudents = 29; // "..should be LESS than 30"

        private string name;
        private IList<Student> students;

        public Course(string name, IList<Student> students = null)
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
                else if (value.Count >= MaximumStudents)
                {
                    throw new ArgumentOutOfRangeException("A course can have less than 30 students");
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
                this.name = value; 
            }
        }

        public void Join(Student student)
        {
            try
            {
                if (this.Students.Count >= MaximumStudents)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    foreach (Student st in this.Students)
                    {
                        if (st.SchoolNumber == student.SchoolNumber)
                        {
                            throw new ArgumentException();
                        }
                    }
                }

                this.Students.Add(student);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Course {0} is attended by the maximum students possible ({1})", this.name, MaximumStudents);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Course {0} is already attended by the student {1} with number {2}", this.name, student.Name, student.SchoolNumber);
            }
        }

        public void Leave(Student student)
        {
            bool studentFound = false;

            foreach (Student st in this.Students)
            {
                if (st.SchoolNumber == student.SchoolNumber)
                {
                    studentFound = true;
                    this.Students.Remove(st);
                    break;
                }
            }

            try
            {
                if (!studentFound)
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The Course {0} is not attended by a student with school number {1}", this.name, student.SchoolNumber);
                throw;
            }
        }
    }
}
