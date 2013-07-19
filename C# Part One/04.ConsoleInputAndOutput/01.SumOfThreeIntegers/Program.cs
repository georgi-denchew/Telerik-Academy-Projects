using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOfThreeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program reads 3 integer numbers from the console and prints their sum");
            Console.Write("Enter the first number here:");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number here:");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number here:");
            int third = int.Parse(Console.ReadLine());
            Console.WriteLine("The sum of the three numbers is: {0}", (first + second + third));
        }
    }
}
