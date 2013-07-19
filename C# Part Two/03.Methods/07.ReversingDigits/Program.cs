using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace _07.ReversingDigits
{
    class Program
    {
        static decimal Reversed(decimal n)
        {
            string str = Convert.ToString(n);
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            string revStr = new string(arr);
            decimal reversed;
            decimal.TryParse(revStr, out reversed);
            return reversed;
        
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter decimal number here: ");
            decimal n = decimal.Parse(Console.ReadLine());
            
            Console.WriteLine(Reversed(n));
        }
    }
}
