using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.TrapezoidArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates a trapezoid's area with manually entered \"a\", \"b\" and \"h\" ");
            Console.Write("Enter \"a\" here:");
            string first = Console.ReadLine();
            Console.Write("Enter \"b\" here:");
            string second = Console.ReadLine();
            Console.Write("Enter \"h\" here:");
            string third = Console.ReadLine();
            int a;
            int b;
            int h;
            int.TryParse(first, out a);
            int.TryParse(second, out b);
            int.TryParse(third, out h);
            Console.WriteLine("The trapezoid's area is {0} square units", (a + b) * h / 2, 0);
        }
    }
}
