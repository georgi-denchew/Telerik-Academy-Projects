using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    class Examples
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("sharo", "male", 2);
            Dog dog2 = new Dog("sparky", "male", 3);
            Frog frog = new Frog("krastava", "female", 1);
            Frog frog2 = new Frog("froggy", "male", 2);
            Cat cat = new Cat("maca", "female", 4);
            Cat cat2 = new Cat("kotan", "male", 5);
            Kitten kitten = new Kitten("malka kotka", 1);
            Kitten kitten2 = new Kitten("vtora malka kotka", 3);
            Tomcat tomcat = new Tomcat("maluk kotarak", 3);
            Tomcat tomcat2 = new Tomcat("vtori maluk kotarak", 2);

            Console.WriteLine("Animal name: {0}     animal sex: {1}     animal age:{2}", kitten.Name, kitten.Sex, kitten.Age);
            Console.WriteLine("Animal name: {0}     animal sex: {1}     animal age:{2}", tomcat.Name, tomcat.Sex, tomcat.Age);
            Console.WriteLine();
            Animal[] animals = new Animal[] { dog, dog2, frog, frog2, cat, cat2, kitten, kitten2, tomcat, tomcat2 };
            animals.AverageAge(); 
        }
    }
}
