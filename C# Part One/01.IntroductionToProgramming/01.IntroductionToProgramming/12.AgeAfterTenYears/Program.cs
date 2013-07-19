using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.AgeAfterTenYears
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your age here:");
            string a = Console.ReadLine();
            int b;
            int.TryParse(a, out b);
            int c = b + 10;
            Console.WriteLine("Your age after ten years will be:" + c);
        }
    }
}
