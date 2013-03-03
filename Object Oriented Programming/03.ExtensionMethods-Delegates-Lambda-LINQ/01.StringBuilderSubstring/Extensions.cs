using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderSubstring
{
    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder input, int index)
        {
            string strInput = input.ToString();
            StringBuilder result = new StringBuilder();
            result.Append(strInput.Substring(index));
            return result;
        }

        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            string strInput = input.ToString();
            StringBuilder result = new StringBuilder();
            result.Append(strInput.Substring(index, length));
            return result;
        }
    }
}
