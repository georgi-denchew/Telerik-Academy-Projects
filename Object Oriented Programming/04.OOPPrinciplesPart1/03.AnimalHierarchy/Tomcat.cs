using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, "male", age)
        {
        }

        public new void MakeSound()
        {
            Console.WriteLine("Tomcat makes a sound: miau");
        }
    }
}
