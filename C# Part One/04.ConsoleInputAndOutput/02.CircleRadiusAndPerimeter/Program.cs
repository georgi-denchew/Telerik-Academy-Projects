using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CircleRadiusAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates the perimeter and area of a circle with manually entered radius");
            Console.Write("Enter radius here:");
            double R = double.Parse(Console.ReadLine());
            double perimeter = (2 * Math.PI * R);
            double area = (Math.PI * R * R);
            Console.WriteLine("The area of the circle is {0}", area);
            Console.WriteLine("The perimeter of the circle is {0}", perimeter);
        }
    }
}
