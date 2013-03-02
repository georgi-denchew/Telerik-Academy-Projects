using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.Point3DTasks
{
    //TASK 01: Create a structure Point3D to hold a 3D-coordinate {X, Y, Z}
    // in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point
    
    //TASK 02: Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
    //Add a static property to return the point O
    
    //TASK 03: Write a static class with a static method to calculate the distance between two points in the 3D space.
    
    //TASK 04:Create a class Path to hold a sequence of points in the 3D space. 
    //Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

    class Examples
    {
        static void Main(string[] args)
        {
            //Task 01 example
            Point3D point1 = new Point3D() { X = 1, Y = 1, Z = 1 }; 
            Console.WriteLine(point1);                              
            Console.WriteLine();

            //Task 02 example
            Console.WriteLine(Point3D.Point0());
            Console.WriteLine();
            
            //Task 03 example
            Point3D point2 = new Point3D() { X = 4, Y = 5, Z = 1 };
            Console.WriteLine(Distance.DistanceCalculator(point1, point2));
            Console.WriteLine();

            //Task 04 example
            Path points = new Path();
            points.Add(point1);
            points.Add(point2);
            Point3D point3 = new Point3D() { X = 4, Y = 6, Z = 7};
            points.Add(point3);

            foreach (Point3D point in points.PointsList)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();

            StreamReader input = new StreamReader(@"../../LoadPath.txt");
            Path loadedPoints = PathStorage.LoadPath(input);
            Console.WriteLine("Loaded points:");
            foreach (Point3D point in loadedPoints.PointsList)
            {
                Console.WriteLine(point);
            }

            PathStorage.SavePath(loadedPoints);
        }
    }
}
