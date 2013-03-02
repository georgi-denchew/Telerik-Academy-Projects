using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.Point3DTasks
{
    public class PathStorage
    {
        public static Path LoadPath(StreamReader input)
        {
            Path path = new Path();
            using (input)
            {
                int lineNumber = 0;
                string line = input.ReadLine();
                while (line != null)
                {
                    lineNumber++;

                    string[] pointsStr = line.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string str in pointsStr)
                    {
                        string[] singlePoint = str.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                        Point3D point = new Point3D() { X = int.Parse(singlePoint[0]), Y = int.Parse(singlePoint[1]), Z = int.Parse(singlePoint[2]) };
                        path.Add(point);
                    }
                    line = input.ReadLine();
                }
            }
            return path;
        }
        public static void SavePath(Path path)
        {
            StreamWriter savePath = new StreamWriter(@"../../SavePath.txt");
            using (savePath)
            {
                foreach (Point3D point in path.PointsList)
                {
                    savePath.Write(point + " ");
                }
            }
        }
    }
}
