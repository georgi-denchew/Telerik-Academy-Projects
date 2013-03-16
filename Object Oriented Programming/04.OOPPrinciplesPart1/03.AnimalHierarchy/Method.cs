using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public static class Method
    {
        public static void AverageAge(this Animal[] animals)
        {
            var dogsAverageAge =
                (from animal in animals
                 where animal is Dog
                 select animal.Age).Average();
            Console.WriteLine("The dogs average age is: {0}", dogsAverageAge);

            var frogsAverageAge =
                (from animal in animals
                 where animal is Frog
                 select animal.Age).Average();
            Console.WriteLine("The frogs average age is: {0}", frogsAverageAge);

            var catsAverageAge =    //Kittens and Tomcats are considered as the Animal Cat
                (from animal in animals
                 where animal is Cat
                 select animal.Age).Average();
            Console.WriteLine("The cats average age is: {0}", catsAverageAge);

        }
    }
}
