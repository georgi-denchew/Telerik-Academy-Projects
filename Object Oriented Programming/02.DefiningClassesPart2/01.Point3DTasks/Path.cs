using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3DTasks
{
    public class Path
    {
        public readonly List<Point3D> pointSequence = new List<Point3D>();

        public List<Point3D> PointsList
        {
            get { return this.pointSequence; }
        }

        public void Add(Point3D point)
        {
            PointsList.Add(point);
        }
    }
}
