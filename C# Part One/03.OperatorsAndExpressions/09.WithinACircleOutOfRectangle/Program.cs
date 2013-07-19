using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.WithinACircleOutOfRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program checks if given point is within the circle K((1,1),3) and out of the rectangle R(top=1 left=-1 width=6 heght=2)");
            Console.Write("Enter X-axis here:");
            string first = Console.ReadLine();
            Console.Write("Enter Y-axis here:");
            string second = Console.ReadLine();
            int Xaxis;
            int.TryParse(first, out Xaxis);
            int Yaxis;
            int.TryParse(second, out Yaxis);
            int CircleXaxis = 1;
            int CircleYaxis = 1;
            int radius = 3;
            if ((Xaxis - CircleXaxis) * (Xaxis - CircleXaxis) + (Yaxis - CircleYaxis) * (Yaxis - CircleYaxis) <= radius*radius)
            {
                Console.WriteLine("This point is in the circle K");
                if (Xaxis < (-1) || Xaxis > (5))
                {
                    Console.WriteLine("This point is out of the rectangle R");
                }
                else
                {
                    if (Yaxis > 1 || Yaxis < -1)
                    {
                        Console.WriteLine("This point is out of the rectangle R");
                    }
                    else
                    {
                        Console.WriteLine("This point is in the rectangle R");
                    }
                }
            }
            else
            {
                Console.WriteLine("This point is out of the Circle K");
                if (Xaxis < (-1) || Xaxis > (5))
                {
                    Console.WriteLine("This point is out of the rectangle R");
                }
                else
                {
                    if (Yaxis > 1 || Yaxis < -1)
                    {
                        Console.WriteLine("This point is out of the rectangle R");
                    }
                    else
                    {
                        Console.WriteLine("This point is in the rectangle R");
                    }
                }
            }
        }
    }
}