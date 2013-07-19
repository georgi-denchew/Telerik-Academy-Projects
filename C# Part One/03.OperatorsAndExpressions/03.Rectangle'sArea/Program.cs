using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Rectangle_sArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter width here:");
            string widthstr = Console.ReadLine();
            Console.Write("Enter height here:");
            string heightstr = Console.ReadLine();
            int width;
            int.TryParse(widthstr, out width);
            int height;
            int.TryParse(heightstr, out height);
            int RectangleArea = width * height;
            Console.Write("A rectangle with {0} width and {1} height has has an area of ", width, height);
            Console.WriteLine("{0} square units", RectangleArea);

        }
    }
}
