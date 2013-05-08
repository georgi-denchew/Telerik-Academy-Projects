namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }

        // Birth date is important information and should be separate property,
        // passed in the constructor
        public DateTime BirthDate { get; private set; }

        public string OtherInfo { get; private set; }

        public Student(string firstName, string LastName, DateTime birthdate, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.BirthDate = birthdate;
            this.OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlderThan = this.BirthDate > other.BirthDate;
            return isOlderThan;
        }
    }
}
