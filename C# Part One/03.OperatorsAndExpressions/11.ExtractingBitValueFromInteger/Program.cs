using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ExtractingBitValueFromInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program extracts the value of a given bit number \"b\" from a given integer \"i\"");
            Console.Write("Enter integer number here:");
            string integernumber = Console.ReadLine();
            Console.Write("Enter bit number here:");
            string bitnumber = Console.ReadLine();
            int i;
            int b;
            int.TryParse(integernumber, out i);
            int.TryParse(bitnumber, out b);
            int mask = 1 << b;
            int iAndMask = i & mask;
            int bit = iAndMask >> b;
            Console.WriteLine("Value = {0}", bit);
        }
    }
}
