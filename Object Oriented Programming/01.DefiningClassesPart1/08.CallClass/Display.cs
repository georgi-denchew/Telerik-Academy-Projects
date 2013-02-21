using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _08.CallClass
{
    public class Display
    {
        private decimal? size;
        private int? colors;

        public Display() : this(null, null)
        {
        }

        public Display(decimal? size, int? colors)
        {
            this.size = size;
            this.colors = colors;
        }

        public decimal? Size
        {
            get { return this.size; }
            set
            {
                if (value >= 0 || value == null)
                {
                    this.size = value;
                }
                else
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid size!");
                        Environment.Exit(0);
                    }
                }
            }
        }
        public int? Colors
        {
            get { return this.colors; }
            set
            {
                if (value >= 0 || value == null)
                {
                    this.colors = value;
                }
                else
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid number of colors");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
