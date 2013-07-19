using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PositionPIntegerV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates if the bit at a given position p in a given integer V equals 1");
            Console.Write("Enter integer number here:");
            string number = Console.ReadLine();
            Console.Write("Enter bit position here:");
            string bitposition = Console.ReadLine();
            int p;
            int v;
            int.TryParse(bitposition, out p);
            int.TryParse(number, out v);
            int mask = 1 << p;
            int vAndMask = v & mask;
            int bit = vAndMask >> p;
            bool check = bit == 1;
            Console.WriteLine(check? "The bit at position {0} is 1" : "The bit at position {0} is different than 1", p);

        }
    }
}
