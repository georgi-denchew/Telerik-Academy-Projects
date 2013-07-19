using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger result = 0;
            
            if (n >= 1 && n <= 99999 && n % 2 != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    BigInteger number = BigInteger.Parse(Console.ReadLine());
                    result = result ^ number;
                }

                Console.WriteLine(result);
            }
        }
    }
}
