using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CartesianCoordinateSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal x = decimal.Parse(Console.ReadLine());
            decimal y = decimal.Parse(Console.ReadLine());
            int zero = 0;
            int one = 1;
            int two = 2;
            int three = 3;
            int four = 4;
            int five = 5;
            int six = 6;

            if (x > 0)
            {
                if (y > 0)
                {

                    Console.WriteLine(one);
                }

                if (y == 0)
                {
                    Console.WriteLine(six);
                }

                if (y < 0)
                {
                    Console.WriteLine(four);
                }
            }

            if (x == 0)
            {
                if (y == 0)
                {
                    Console.WriteLine(zero);
                }

                else
                {
                    Console.WriteLine(five);
                }
            }

            if (x < 0)
            {
                if (y > 0)
                {
                    Console.WriteLine(two);
                }

                if (y == 0)
                {
                    Console.WriteLine(six);
                }

                if (y < 0)
                {
                    Console.WriteLine(three);
                }
            }
        }
    }
}