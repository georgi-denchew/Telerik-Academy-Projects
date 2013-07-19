using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.TrailingZerosForGivenN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates for given N how many trailng zereos present at the end of number N!");
            Console.Write("Enter N here: ");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger x = n;
            BigInteger divisor = 5;
            BigInteger result = 1;
            while ( n > 1)
            {
                result = result * n;
                n--;
            }
            Console.WriteLine("N! is: {0}", result);
            BigInteger zeros = 0;
            while ( result % 10 == 0)
            {
                result = result / 10;
                zeros++;
            }
            Console.WriteLine();
            Console.WriteLine("The number of zeros is: {0}", zeros);
        }
    }
}
