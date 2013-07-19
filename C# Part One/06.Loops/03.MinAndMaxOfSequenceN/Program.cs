using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinAndMaxOfSequenceN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program gives the minimal and maximal from the sequence of N integer numbers");
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter number 1 here: ");
            int first = int.Parse(Console.ReadLine());
            int min = first;
            int max = first;
            int b = 2;
            for (int i = 2; i <= n; i++)
            {
                Console.Write("Enter number {0} here: ", b);
                int a = int.Parse(Console.ReadLine());
                if (a > max)
                {
                    max = a;
                }
                if (a < min)
                {
                    min = a;
                }
                b++;
            }
            Console.WriteLine("The maximal number is: {0}", max);
            Console.WriteLine("The minimal number is: {0}", min);
        }
    }
}
