using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace _01.MathExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());
            decimal mod = m % 180;
            Console.WriteLine(mod);
            Console.WriteLine((int)mod);
            decimal result = ((n * n + (1 / (m * p)) + 1337) / 
            (n - (decimal)128.523123123 * p)) + (decimal)Math.Sin((int)mod);

            Console.WriteLine("{0:0.000000}", result);
        }
    }
}
