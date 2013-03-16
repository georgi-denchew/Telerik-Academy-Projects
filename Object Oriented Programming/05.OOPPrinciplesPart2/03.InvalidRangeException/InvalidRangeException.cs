using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InvalidRangeException
{
    public class InvalidRangeException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRangeException(string message, Exception innerExcp, T start, T end)
            : base(message, innerExcp)
        {
            this.start = start;
            this.end = end;
        }
    }
}
