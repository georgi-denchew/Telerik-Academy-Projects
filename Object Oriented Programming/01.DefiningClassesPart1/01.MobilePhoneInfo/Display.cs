using System;

namespace _01.MobilePhoneInfo
{
    public class Display
    {
        private decimal size;
        private int colors;

        public Display()
        {
            this.size = 4.8M;
            this.colors = 16000000;
        }

        public decimal Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public int Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }
    }
}
