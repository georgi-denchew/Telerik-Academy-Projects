using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    class Frog : Animal, ISound
    {
        public Frog(string name, string sex, int age)
        {
            base.name = name;
            base.sex = sex;
            base.age = age;
        }

        public void MakeSound()
        {
            Console.WriteLine("The Frog makes a sound: Cra Cra");
        }
    }
}
