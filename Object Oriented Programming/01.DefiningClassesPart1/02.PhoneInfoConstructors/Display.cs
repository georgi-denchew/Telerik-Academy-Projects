﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PhoneInfoConstructors
{
    public class Display
    {
        private decimal? size;
        private int? colors;

        public Display()
        {
            this.size = null;
            this.colors = null;
        }

        public decimal? Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public int? Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }
    }
}
