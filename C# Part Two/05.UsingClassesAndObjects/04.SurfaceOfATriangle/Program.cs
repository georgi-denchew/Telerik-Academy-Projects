using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SurfaceOfATriangle
{
    class Program
    {
        static int S1(int a, int h)
        {
            return a * h / 2;
        }
        
        static int S2(int a, int b, int c)
        {
            int p = (a + b + c) / 2;
            return (int)Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
        }

        static int S3(int a, int b, int alfa)
        {
            return (a * b * (int)Math.Sin(alfa)) / 2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for side and altitude. Enter 2 for three sides. Enter 3 for two sides and an angle between them");
            int choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                Console.Write("Enter side: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter altitude: ");
                int h = int.Parse(Console.ReadLine());
                Console.WriteLine(S1(a, h));
            }

            else if (choise == 2)
            {
                Console.WriteLine("Enter three sides:");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());
                Console.WriteLine(S2(a, b, c));
            }

            else if (choise == 3)
            {
                Console.WriteLine("Enter two sides:");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter an angle");
                int alfa = int.Parse(Console.ReadLine());
                S3(a, b, alfa);
            }
        }
    }
}
