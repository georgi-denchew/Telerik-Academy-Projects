using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintingOneToN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints all the number from 1 to N");
            Console.Write("Please enter number N here: ");
            int n = int.Parse(Console.ReadLine());
            int a = 1;
            while (a <= n)
            {
             Console.WriteLine(a);
                a++;
            }
        }
    }
}
