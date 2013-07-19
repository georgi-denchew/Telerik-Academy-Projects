using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter binary number: ");
            char[] binStr = Console.ReadLine().ToCharArray();
            Array.Reverse(binStr);
            string revStr = new string(binStr);
            int dec = 0;
            int count = 0;

            foreach (char digit in revStr)
            {
                if (digit == '1')
                {
                    dec = (int)Math.Pow(2, count) + dec;
                }
                count++;
            }

            Console.WriteLine(dec);
        }
    }
}