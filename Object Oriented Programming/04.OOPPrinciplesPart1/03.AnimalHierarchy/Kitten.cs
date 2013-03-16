using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, "female", age)
        {
        }

        public new void  MakeSound()
        {
            Console.WriteLine("Kitten makes a sound: miau");
        }
        
    }
}
