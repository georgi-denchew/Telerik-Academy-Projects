using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PrintGreaterWithoutIf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints the greater of two given numbers without using if statements");
            Console.Write("Enter the first number here:");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number here:");
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine("The greater number is: {0}", Math.Max(first, second));
            Console.WriteLine("greater: {0}", (first + second + Math.Abs(first - second)) / 2);
            Console.WriteLine("smaller: {0}", (first + second - Math.Abs(first - second)) / 2);
        }
    }
}
