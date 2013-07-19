using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IntervalOneToN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints all the numbers in the interval [1,n], each on a single line");
            Console.Write("Enter number n here: ");
            int n = int.Parse(Console.ReadLine());
            for (int first = 1; first <= n; first++)
            {
                Console.WriteLine(first);
            }

        }
    }
}
