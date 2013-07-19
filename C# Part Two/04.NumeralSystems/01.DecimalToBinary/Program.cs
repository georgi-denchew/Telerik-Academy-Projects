using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter decimal number: ");
            int d = int.Parse(Console.ReadLine());
            int remainder;
            string result = null;

            while (d > 0)
            {
                remainder = d % 2;
                d /= 2;
                result = remainder.ToString() + result;
            }

            Console.WriteLine("Binary: {0}", result);
        }
    }
}
