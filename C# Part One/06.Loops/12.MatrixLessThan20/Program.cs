using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MatrixLessThan20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program reads a positive integer number N (N < 20) and prints a matrix");
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            for (int rows = 1; rows <= n; rows++)
            {
                Console.WriteLine();
                for (int cols = rows; cols < rows + n; cols++)
                {
                    Console.Write("{0} ", cols);
                }
            }
            Console.WriteLine();
        }
    }
}
