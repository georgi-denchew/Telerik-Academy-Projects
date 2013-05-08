namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get 
            {
                return this.radius; 
            }

            protected set
            {
                // I thought of extracting the checkings to a method, but the messages
                // that the user sees when they're thrown should be differnet for each property
                // Didn't check if value == null - it will always be false unsless the variable is "double?"
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new OverflowException("Circle radius value caused stack overflow");
                }
                else if (double.IsNaN(value))
                {
                    throw new FormatException("Invalid circle radius value");
                }

                this.radius = value;
            }
        }
        
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
