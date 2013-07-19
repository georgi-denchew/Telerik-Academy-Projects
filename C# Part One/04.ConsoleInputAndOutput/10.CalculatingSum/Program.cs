using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CalculatingSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates the sum 1 + 1/2 - 1/3 + 1/4 - 1/5 +... with accuracy of 0.001");
            double dividedby = 2;
            double temporary = 1;
            double result = 1;

            while (temporary >= 0.001)
            {
                temporary = 1.0 / dividedby;

                if (dividedby % 2 == 0)
                {
                    result = result + temporary;
                }
                else
                {
                    result = result - temporary;
                }
                dividedby++;
            }
            Console.WriteLine("");
            Console.WriteLine("The result is: " + result);
        }
    }
}

