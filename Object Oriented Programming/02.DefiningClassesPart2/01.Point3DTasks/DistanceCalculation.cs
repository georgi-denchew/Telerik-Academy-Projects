using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3DTasks
{
    public static class Distance
    {
        
        static Distance()
        {
        }

        public static decimal DistanceCalculator(Point3D point1, Point3D point2)
        {
            int distX = (point2.X - point1.X) * (point2.X - point1.X);
            int distY = (point2.Y - point1.Y) * (point2.Y - point1.Y);
            int distZ = (point2.Z - point1.Z) * (point2.Z - point1.Z);
            decimal dist = distX + distY + distZ;
            return (decimal)Math.Sqrt((double)dist);

        }
    }
}
