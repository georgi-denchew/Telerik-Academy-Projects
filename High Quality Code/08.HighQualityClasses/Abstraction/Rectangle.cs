namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get 
            { 
                return this.height; 
            }

            protected set 
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new OverflowException("Rectangle height value caused stack overflow");
                }
                else if (double.IsNaN(value))
                {
                    throw new FormatException("Invalid rectangle height value");
                }

                this.height = value; 
            }
        }

        public double Width
        {
            get 
            { 
                return this.width;
            }

            protected set 
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new OverflowException("Rectangle width value caused stack overflow");
                }
                else if (double.IsNaN(value))
                {
                    throw new FormatException("Invalid rectangle width value");
                }

                this.width = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
