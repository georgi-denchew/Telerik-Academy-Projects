using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOfNNumbersOfFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program reads a number N and calculates the sum of the first N numbers of the sequence of Fibonacci");
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            int first = 0;
            int second = 1;
            int third = first + second;
            int a = 3;
            int sum = 1;
            while (a <= n)
            {
                third = first + second;
                first = second;
                second = third;
                sum = sum + third;
                a++;
            }
            Console.WriteLine("The sum of the first N numbers is: {0}", sum);
        }
    }
}
