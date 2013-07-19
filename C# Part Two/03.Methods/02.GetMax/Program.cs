using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GetMax
{
    class Program
    {
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter first integer here: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer here: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter third integer here: ");
            int third = int.Parse(Console.ReadLine());

            int check = GetMax(first, second);
            int biggest = GetMax(third, check);

            Console.WriteLine("The biggest of the three ingeres is: {0}", biggest);
            
        }
    }
}
