using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SumOfSubsetEqualsZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates if the sum of a five number subset is zero");
            Console.WriteLine("Enter the first number here: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number here: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the third number here: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the fourth number here:");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the fifth number here: ");
            int e = int.Parse(Console.ReadLine());

            if ((a + b) == 0 || (a + c) == 0 || (a + d) == 0 || (a + e) == 0 || (a + b + c) == 0 || (a + b + d) == 0 || (a + b + e) == 0 || (a + b + c + d) == 0 ||
            (a + b + c + d + e) == 0 || (a + b + c + e) == 0 || (a + b + d + e) == 0 || (a + c + d) == 0 || (a + c + e) == 0 || (a + c + d + e) == 0 ||
            (a + d + e) == 0 || (b + c) == 0 || (b + c + d) == 0 || (b + c + e) == 0 || (b + c + d + e) == 0 || (b + d) == 0 || (b + d + e) == 0 || (b + e) == 0
            || (c + d) == 0 || (c + d + e) == 0 || (c + e) == 0 || (d + e) == 0)
            {
                Console.WriteLine("There is a subset of these numbers that equals zero");
            }

            else
            {
                Console.WriteLine("There is no subset of these numbers that equals zero");
            }
        }
    }
}
