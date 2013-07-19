using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.IsGivenPointWithinCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This Program checks if manually entered points are within a circle with a center point XAxis=0 and YAxis=5 and manually entered radius");
            Console.WriteLine("Enter X-axis here: ");
            string XAxis = Console.ReadLine();
            Console.WriteLine("Enter Y-axis here: ");
            string YAxis = Console.ReadLine();
            Console.WriteLine("Enter Radius here: ");
            string Radius = Console.ReadLine();
            int ConvertedXAxis;
            int.TryParse(XAxis, out ConvertedXAxis);
            int ConvertedYAxis;
            int.TryParse(YAxis, out ConvertedYAxis);
            int ConvertedRadius;
            int.TryParse(Radius, out ConvertedRadius);
            int CircleXAxis = 0;
            int CircleYAxis = 5;
            bool check = (ConvertedXAxis - CircleXAxis) * (ConvertedXAxis - CircleXAxis) + (ConvertedYAxis - CircleYAxis) * (ConvertedYAxis - CircleYAxis) < ConvertedRadius * ConvertedRadius;
            Console.WriteLine(check ? "The given point is within the circle" : "The given point is not within the circle");
        }
    }
}
