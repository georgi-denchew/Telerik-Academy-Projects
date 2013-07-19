using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _09._100MembersOfFibonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints the first 100 members of the sequence of Fibonacci");
            BigInteger first = 0;
            BigInteger second = 1;
            BigInteger temp1 = first + second;
            BigInteger temp2 = temp1 + second;
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(temp1);
            Console.WriteLine(temp2);

            for (int a = 1; a <= 96; a++) 
            {
                BigInteger temp3 = temp2 + temp1;
                Console.WriteLine(temp3);
                temp1 = temp2;
                temp2 = temp3; 
            }

        }
    }
}
