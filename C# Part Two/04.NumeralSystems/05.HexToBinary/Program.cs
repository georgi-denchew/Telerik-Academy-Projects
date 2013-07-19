using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HexToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter hexadecimal: ");
            string hex = Console.ReadLine();
            string bin = Convert.ToString(Convert.ToInt32(hex, 16), 2);
            Console.WriteLine(bin);
        }
    }
}
