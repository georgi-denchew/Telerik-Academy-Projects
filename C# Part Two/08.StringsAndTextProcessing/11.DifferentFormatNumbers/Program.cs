using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.DifferentFormatNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("{0, 15}", number);
            Console.WriteLine("{0, 15:X}", number);
            Console.WriteLine("{0, 15:P}", number);
            Console.WriteLine("{0, 15:E}", number);
        }
    }
}
