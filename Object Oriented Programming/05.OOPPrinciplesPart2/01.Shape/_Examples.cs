using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    class _Examples
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(4, 5);
            Rectangle rectangle = new Rectangle(5, 6);
            Circle circle = new Circle(3);
            Shape[] figures = new Shape[] { triangle, rectangle, circle };

            foreach (Shape figure in figures)
            {
                Console.WriteLine(figure.CalculateSurface());
            }
        }
    }
}
