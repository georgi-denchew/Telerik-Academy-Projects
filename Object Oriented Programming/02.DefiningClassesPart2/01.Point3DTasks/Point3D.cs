using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3DTasks
{
    public struct Point3D
    {
        private static readonly Point3D point0 = new Point3D() { X = 0, Y = 0, Z = 0 }; 

        public static Point3D Point0()
        {
            return point0;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }
}
