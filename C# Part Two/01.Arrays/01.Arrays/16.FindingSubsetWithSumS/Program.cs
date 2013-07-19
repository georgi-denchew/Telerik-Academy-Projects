using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.FindingSubsetWithSumS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sum: ");
            long sum = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter length: ");
            long length = long.Parse(Console.ReadLine());
            long[] elements = new long[length];
            int count = 0;
            string sub = "";

            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine("Enter [{0}]: ",i);
                elements[i] = long.Parse(Console.ReadLine());
            }

            int maxSub = (int)Math.Pow(2, length) - 1;

            for (int i = 1; i < maxSub; i++)
            {
                sub = "";
                long checkSum = 0;

                for (int j = 0; j < length; j++)
                {
                    int mask = 1 << j;
                    int nAndMask = i & mask;
                    int bit = nAndMask >> j;

                    if (bit == 1)
                    {
                        checkSum += elements[j];
                        sub = sub + " " + elements[j];
                    }
                }

                if (checkSum == sum)
                {
                    Console.WriteLine("Number of subsets that have the sum {0}", sum);
                    count++;
                    Console.WriteLine("Current subset has the sum {0}: {1} ", sum, sub);
                }
            }
            Console.WriteLine(count);
        }
    }
}
