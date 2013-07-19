using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.StringObjectString
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = "Hello";
            string two = "World";
            object concatenation = one + " " + two;
            string third = concatenation.ToString();
            Console.WriteLine("First String:" + one);
            Console.WriteLine("Second String:" + two);
            Console.WriteLine("Object:" + concatenation);
            Console.WriteLine("Third String:" + third);
        }
    }
}
