using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ToStringOverride
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
            set { this.size = value; }
        }
        public int? Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }
    }
}
