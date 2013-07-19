using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FloatngPointComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number here:");
            string numberone = Console.ReadLine();
            decimal firstdecimal;

            if (decimal.TryParse(numberone, out firstdecimal))
            {
                Console.WriteLine("Enter the second number here:");
                string numbertwo = Console.ReadLine();
                decimal seconddecimal;
                if (decimal.TryParse(numbertwo, out seconddecimal))
                {
                    bool precision = Math.Abs(firstdecimal - seconddecimal) < 0.000001m;
                    Console.WriteLine("The numbers {0} and {1} are {2} with a precision of 0.000001", firstdecimal, seconddecimal, precision ? "equal" : "not equal");
                }

                else
                {
                    Console.WriteLine("Invalid Decimal Number");
                }
            }
            else
            {
                Console.WriteLine("Invalid Decimal Number");
            }
        }
    }
}
