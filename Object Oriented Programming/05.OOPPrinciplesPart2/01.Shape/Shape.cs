using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    public abstract class Shape
    {
        protected decimal width;
        protected decimal height;

        public Shape(decimal width, decimal height)
        {
            this.width = width;
            this.height = height;
        }

        public abstract decimal CalculateSurface();
    }
}
