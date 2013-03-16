using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    public class Circle : Shape
    {
        public Circle(decimal radius)
            : base(radius, radius)
        {
        }

        public override decimal CalculateSurface()
        {
            return (base.height * base.height * (decimal)Math.PI);
        }
    }
}
