using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Hello
{
    class Program
    {
        static void Name()
        {
            Console.Write("Enter name here: ");
            string n = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", n);
        }
        static void Main(string[] args)
        {
            Name();
        }
    }
}
