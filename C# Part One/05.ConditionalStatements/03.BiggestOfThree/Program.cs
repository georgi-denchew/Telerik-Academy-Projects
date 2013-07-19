using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BiggestOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program finds the biggest of three integers");
            Console.Write("Enter first integer here: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer here: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter third integer here: ");
            int third = int.Parse(Console.ReadLine());

            if (first >= second)
            {

                if (first > third)
                {
                    Console.WriteLine("The biggest number is: " + first);
                }

                else 
                {
                    Console.WriteLine("The biggest number is: " + third);
                }
            }

            else
            {
                if (second > third)
                {
                    Console.WriteLine("The biggest number is: " + second);
                }

                else
                {
                    Console.WriteLine("The biggest number is: " + third);
                }
            }
        }
    }
}
