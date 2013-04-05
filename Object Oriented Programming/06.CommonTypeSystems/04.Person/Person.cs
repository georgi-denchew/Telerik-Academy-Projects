using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    public class Person
    {
        private string name;
        private int? age;

        public int? Age
        {
            get { return age; }
            private set { age = value; }
        }


        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Person(string name, int? age = null)
        {
            this.name = name;
            this.age = age;
        }

        private bool AgeSpecified()
        {
            if (this.Age != null)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Name: {0}", this.Name);
            builder.AppendLine();

            if (this.AgeSpecified())
            {
                builder.AppendFormat("Age: {0}", this.Age);
            }
            else
            {
                builder.AppendFormat("Age: not specified");
            }
            builder.AppendLine();
            return builder.ToString();
        }
    }
}
