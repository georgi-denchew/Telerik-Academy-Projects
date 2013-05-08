using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Size
{
    class Tests
    {
        static void Main(string[] args)
        {
            Figure size = new Figure(5, 6);
            Console.WriteLine(Figure.GetRotatedFigure(size, 45));
        }
    }
}
