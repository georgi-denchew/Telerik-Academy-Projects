using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.IsBitThreeOneOrZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your number here: ");
            string EnteredNumber = Console.ReadLine();
            int ConvertedNumber;
            int.TryParse(EnteredNumber, out ConvertedNumber);
            int BitPositionThree = 3;
            int Mask = 1 << BitPositionThree;
            int ConvertedNumberAndMask = ConvertedNumber & Mask;
            int bit = ConvertedNumberAndMask >> BitPositionThree;
            Console.WriteLine(bit);
            Console.WriteLine(Convert.ToString(ConvertedNumber, 2).PadLeft(32, '0'));
        }
    }
}
