using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
        {
            base.firstName = firstName;
            base.lastName = lastName;
            this.grade = grade;

        }

        public int Grade
        {
            get { return this.grade; }
        }

    }
}
