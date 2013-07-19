using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DescendingOrderOfThreeValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program sorts three values in a descending order");
            Console.Write("Enter the first value here: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second value here: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter the third value here: ");
            int third = int.Parse(Console.ReadLine());

            if (first > second)
            {
                if (second > third)
                {
                    Console.WriteLine("The order is: {0}, {1}, {2}", first, second, third);
                }

                else
                {
                    
                    if (third > first)
                    {
                        Console.WriteLine("The order is: {0}, {1}, {2}", third, first, second);
                    }

                    else
                    {
                        Console.WriteLine("The order is: {0}, {1}, {2}", first, third, second);
                    }
                }
            }

            else
            {
                if (first > third)
                {
                    Console.WriteLine("The order is: {0}, {1}, {2}", second, first, third);
                }

                else
                {

                    if (second > third)
                    {
                        Console.WriteLine("The order is: {0}, {1}, {2}", second, third, first);
                    }

                    else
                    {
                        Console.WriteLine("The order is: {0}, {1}, {2}", third, second, first);
                    }
                }
            }
        }
    }
}
