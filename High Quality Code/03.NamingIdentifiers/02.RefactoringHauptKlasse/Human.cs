using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactoringHauptKlasse
{
    /// <summary>
    /// This class has a method instead of a constructor, that "creates"
    /// an instance of a human with the common properties for a human.
    /// </summary>
    public class Human
    {
        /// <summary>
        /// I decided to add fields, instead of using automatic properties - I think it's more correct
        /// </summary>
        private Gender gender;
        private string name;
        private int age;

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        /// <summary>
        /// "Creates" a human with name and gender depending on it's age
        /// (it is used instead of a constructor).
        /// </summary>
        /// <param name="age">if the age is an even number the instance will be male, 
        /// otherwise it will be female</param>
        public void CreateHuman(int age)
        {
            this.Age = age;
            if (age % 2 == 0)
            {
                this.Name= "Male Name";
                this.Gender = Gender.Male;
            }
            else
            {
                this.Name = "Female Name";
                this.Gender = Gender.Female;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name);
            result.Append(Environment.NewLine);
            result.Append(this.Age);
            result.Append(Environment.NewLine);
            result.Append(this.Gender);

            return result.ToString();
        }
    }
}
