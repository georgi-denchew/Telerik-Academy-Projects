using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PrintingNotDivisibleByThreeAndSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints all the numbes from 1 to N, taht are not divisible by 3 and 7 at the same time");
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
