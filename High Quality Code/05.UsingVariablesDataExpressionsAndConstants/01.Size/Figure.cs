using System;
using System.Text;

namespace _01.Size
{
    /// <summary>
    /// Renamed class Size to Figure - I think it's more suitable
    /// </summary>
    public class Figure
    {
        /// <summary>
        /// I consider width and height as fields, so I made them private.
        /// </summary>
        private double width; 
        private double height;

        public Figure(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Figure GetRotatedFigure(Figure size, double figureAngle)
        {
            double rotatedFigureWidth = Math.Abs(Math.Cos(figureAngle)) * size.width + 
                Math.Abs(Math.Sin(figureAngle)) * size.height;
            double rotatedFigureHeight = Math.Abs(Math.Sin(figureAngle)) * size.width +
                Math.Abs(Math.Cos(figureAngle)) * size.height;
            
            Figure rotatedFigure = new Figure(rotatedFigureWidth, rotatedFigureHeight);
            return rotatedFigure;

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}, {1}", this.width, this.height);
            return result.ToString();
        }
    }
}
