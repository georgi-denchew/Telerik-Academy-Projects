using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ExchangingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("This program exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of a given unsigned integer");
            Console.Write("Enter unsigned integer number here: ");
            uint n = uint.Parse(Console.ReadLine());
            uint bitThree = (n & (1 << 3)) >> 3;
            uint bitFour = (n & (1 << 4)) >> 4;
            uint bitFive = (n & (1 << 5)) >> 5;
            uint bitTwentyFour = (n & (1 << 24)) >> 24;
            uint bitTwentyFive = (n & (1 << 25)) >> 25;
            uint bitTwentySix = (n & (1 << 26)) >> 26;
            uint temp;
            uint result;

            temp = ((bitThree == 0) ? (temp = n & ~((uint)(1 << 24))) : (temp = n | (1 << 24)));
            result = temp;
            temp = ((bitFour == 0) ? (temp = result & ~((uint)(1 << 25))) : (temp = result | (1 << 25)));
            result = temp;
            temp = ((bitFive == 0) ? (temp = result & ~((uint)(1 << 26))) : (temp = result | (1 << 26)));
            result = temp;
            temp = ((bitTwentyFour == 0) ? (temp = result & ~((uint)(1 << 3))) : (temp = result | (1 << 3)));
            result = temp;
            temp = ((bitTwentyFive == 0) ? (temp = result & ~((uint)(1 << 4))) : (temp = result | (1 << 4)));
            result = temp;
            temp = ((bitTwentySix == 0) ? (temp = result & ~((uint)(1 << 5))) : (temp = result | (1 << 5)));
            result = temp;
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
        }
    }
}
