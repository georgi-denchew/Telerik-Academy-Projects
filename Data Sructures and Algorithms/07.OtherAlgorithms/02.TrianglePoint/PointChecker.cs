namespace _02.TrianglePoint
{
    using System;
    using System.Linq;

    class PointChecker
    {
        static void Main(string[] args)
        {
            Console.Write("Enter triangle-point coordinates in the format aX aY bX bY cX cY: ");
            string[] strPoints = Console.ReadLine().Split(' ');

            double aX = double.Parse(strPoints[0]);
            double aY = double.Parse(strPoints[1]);
            double bX = double.Parse(strPoints[2]);
            double bY = double.Parse(strPoints[3]);
            double cX = double.Parse(strPoints[4]);
            double cY = double.Parse(strPoints[5]);

            Console.Write("Enter coordinates for the point to be checked: ");
            string[] strCheckedPoint = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            double pX = double.Parse(strCheckedPoint[0]);
            double pY = double.Parse(strCheckedPoint[1]);

            double dX = pX - cX;
            double dY = pY - cY;

            double A = aX - cX;
            double B = aY - cY;
            double C = bX - cX;
            double D = bY - cY;

            double denom = A * D - B * C;

            double alpha = D * dX + -C * dY;

            alpha /= denom;

            double beta = -B * dX + A * dY;

            beta /= denom;

            double gamma = 1.0 - (alpha + beta);

            bool inTriangle = alpha >= 0 && beta >= 0 && gamma >= 0;

            if (inTriangle)
            {
                Console.WriteLine("The point is in the given triangle.");
            }
            else
            {
                Console.WriteLine("The point is outside the given triangle.");
            }
        }
    }
}