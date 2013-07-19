using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BinaryToHex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter binary: ");
            string bin = Console.ReadLine();
            string hex = Convert.ToString(Convert.ToInt32(bin, 2), 16);
            Console.WriteLine(hex);
        }
    }
}
