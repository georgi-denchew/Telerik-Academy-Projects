using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DivideBySevenAndFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write number here:");
            string number = Console.ReadLine();
            int value;
            int.TryParse(number, out value);
            bool DividedByFive = value % 5 == 0;
            bool DividedBySeven = value % 7 == 0;
            Console.WriteLine((DividedByFive && DividedBySeven)? "Your number can be divided by five and seven at the same time" : "Your number cannot be divided by five and seven at the same time");


        }
    }
}
