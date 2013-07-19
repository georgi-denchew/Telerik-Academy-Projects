using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToHex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter decimal number: ");
            int dec = int.Parse(Console.ReadLine());
            string hex = dec.ToString("X");
            Console.WriteLine(hex);
        }
    }
}
