namespace _01_03.UnitTesting
{
    using System;

    public class Student
    {
        private string name;
        private int schoolNumber;

        public Student(string name, int schoolNumber)
        {
            this.Name = name;
            this.SchoolNumber = schoolNumber;
        }

        public int SchoolNumber
        {
            get 
            { 
                return this.schoolNumber; 
            }

            protected set 
            {
                if (value <= 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Students cannot have a school number smaller 10 000 and larger than 99 999");
                }

                this.schoolNumber = value; 
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
                    throw new ArgumentException("Name cannot be null or an empty string");
                }

                this.name = value; 
            }
        }
    }
}
