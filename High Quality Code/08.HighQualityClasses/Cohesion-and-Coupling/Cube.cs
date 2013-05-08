namespace CohesionAndCoupling
{
    using System;

    public class Cube
    {
        private double width;
        private double height;
        private double depth;

        public Cube(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Depth
        {
            get 
            { 
                return this.depth; 
            }

            protected set 
            {
                if (value > double.MaxValue || value < double.MinValue)
                {
                    throw new OverflowException("Cube depth value caused stack overflow");
                }
                else if (double.IsNaN(value))
                {
                    throw new FormatException("Invalid cube depth value");
                }

                this.depth = value; 
            }
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
                    throw new OverflowException("Cube height value caused stack overflow");
                }
                else if (double.IsNaN(value))
                {
                    throw new FormatException("Invalid cube height value");
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
                    throw new OverflowException("Cube width value caused stack overflow");
                }
                else if (double.IsNaN(value))
                {
                    throw new FormatException("Invalid cube width value");
                }

                this.width = value; 
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = CalculateDistance.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = CalculateDistance.CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = CalculateDistance.CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = CalculateDistance.CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
