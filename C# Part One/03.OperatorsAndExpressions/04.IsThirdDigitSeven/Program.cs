using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.IsThirdDigitSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your four-digit number here: ");
            string EnteredNumber = Console.ReadLine();
            int ConvertedNumber;
            int.TryParse(EnteredNumber, out ConvertedNumber);
            int DividedByHundred = ConvertedNumber / 100;
            bool IsThirdDigitSeven = (Math.Abs(DividedByHundred) % 10) == 7;
            Console.WriteLine(IsThirdDigitSeven ? "The third digit of your number is 7" : "The third digit of your number is different than 7");
        }
    }
}
