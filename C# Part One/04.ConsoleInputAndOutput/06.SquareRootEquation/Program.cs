using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SquareRootEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program gives the real roots to the quadtratic equation a*x*x + b*x + c=0 with manually entered a, b and c");
            Console.Write("Enter a here: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b here: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter c here: ");
            int c = int.Parse(Console.ReadLine());
            int D = (b * b) - (4 * a * c);

            if (D < 0)
            {
                Console.WriteLine("The equation has no real roots");
            }

            else
            {

                if (D == 0)
                {
                    double x = (-b) / (2.0 * a);
                    Console.WriteLine("The root to the equation is: " + x);
                }

                else
                {
                    double x1 = (((-b) + System.Convert.ToDouble(Math.Sqrt(D))) / (2.0 * a));
                    double x2 = (((-b) - System.Convert.ToDouble(Math.Sqrt(D))) / (2.0 * a));
                    Console.WriteLine("The roots to the equation are: {0} and {1}", x1, x2);
                }
            }
        }
    }
}