using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOfNNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates and prints the sum of n numbers");
            Console.Write("Enter the count of numbers you want: ");
            int n = int.Parse(Console.ReadLine());
            int b;
            int result = 0;
            for (int a = 1; a <= n; a++)
            {
                Console.Write("Enter number here: ");
                b = int.Parse(Console.ReadLine());
                result = result + b;
            }
            Console.WriteLine("The sum of the numbers you entered is: " + result);
        }
    }
}
