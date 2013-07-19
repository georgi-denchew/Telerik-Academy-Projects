using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExchangingIntegerValues
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program examines two integer vairables and exchanges their values if the first one is greater than the second one");
            Console.Write("Enter the first variable here: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second variable here: ");
            int second = int.Parse(Console.ReadLine());
            int x;

            if (first > second)
            {
                x = first;
                first = second;
                second = x;
                Console.WriteLine("The first variable is: " + first);
                Console.WriteLine("The second variable is: " + second);
            }
            else
            {
                Console.WriteLine("The second variable equals the first or it's greater than it");
            }
        }
    }
}
