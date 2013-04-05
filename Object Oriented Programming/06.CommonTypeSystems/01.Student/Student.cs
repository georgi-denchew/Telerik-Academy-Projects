using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Student
{
    public enum Universities { SofiaUniversity, TechnologyUniversity, UNWE };

    public enum Faculties { Law, IT, Economics };

    public enum Specialties { Lawyer, SoftwareEngineering, Marketing };
    


    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;       
        private string socialSecurityNumber;
        private string address;
        private int phone;
        private string email;
        private int course;
        private Universities university;
        private Faculties faculty;
        private Specialties specialty;

        public string Address
	    {
		    get { return address;}
		    private set { address = value;}
	    }
        
        public Specialties Specialty
        {
            get { return specialty; }
            private set { specialty = value; }
        }

        public Faculties Faculty
        {
            get { return faculty; }
            private set { faculty = value; }
        }
        
        public Universities University
        {
            get { return university; }
            private set { university = value; }
        }

                public int Course
        {
            get { return course; }
            private set { course = value; }
        }

                public string Email
        {
            get { return email; }
            private set { email = value; }
        }
        
        public int Phone
        {
            get { return phone; }
            private set { phone = value; }
        }
        
        public string SocialSecurityNumber
        {
            get { return socialSecurityNumber; }
            private set { socialSecurityNumber = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            private set { middleName = value; }
        }
        
        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }

        public Student(string firstName, string middleName, string lastName, string socialSecurityNumber, string address, int phone, 
            string email, int course, Universities university, Faculties faculty, Specialties specialty)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.course = course;
            this.university = university;
            this.faculty = faculty;
            this.specialty = specialty;
        }

        
        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
            {
                return false;
            }

            if (! Object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }

            if (! Object.Equals(this.MiddleName, student.MiddleName))
            {
                return false;
            }

            if (! Object.Equals(this.LastName, student.LastName))
            {
                return false;
            }

            if (! Object.Equals(this.SocialSecurityNumber, student.SocialSecurityNumber))
            {
                return false;
            }

            if (this.Phone != student.Phone)
            {
                return false;
            }

            if (! Object.Equals(this.Email, student.Email))
            {
                return false;
            }

            if (this.Course != student.Course)
            {
                return false;
            }

            if (! Object.Equals(this.University, student.University))
            {
                return false;
            }

            if (!Object.Equals(this.Faculty, student.Faculty))
            {
                return false;
            }

            if (! Object.Equals(this.Specialty, student.Specialty))
            {
                return false;
            }

            return true;
        }

        public static bool operator == (Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            builder.AppendLine();
            builder.AppendLine(this.SocialSecurityNumber);
            builder.AppendLine(this.Address);
            builder.AppendLine(this.Phone.ToString());
            builder.AppendLine(this.Course.ToString());
            builder.AppendLine(this.Specialty.ToString());
            builder.AppendLine(this.University.ToString());
            builder.AppendLine(this.Faculty.ToString());
            return builder.ToString();
        }

        public Student Clone() //TASK 02 -- Creating Deep Copy
        {
            Student clone = new Student(this.FirstName, this.MiddleName, this.LastName,
                this.SocialSecurityNumber, this.Address, this.Phone, this.Email,
                this.Course, this.University, this.Faculty, this.Specialty);
            return clone;
        }

        object ICloneable.Clone() //Implicit implementation
        {
            return this.Clone();
        }

        public int CompareTo(Student other) //TASK 03
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            if (this.MiddleName.CompareTo(other.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }

            if (this.LastName.CompareTo(other.LastName)!= 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }

            return this.SocialSecurityNumber.CompareTo(other.SocialSecurityNumber);
        }

    }
}
