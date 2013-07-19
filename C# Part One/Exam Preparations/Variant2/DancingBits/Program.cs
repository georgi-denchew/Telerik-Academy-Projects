using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort k = ushort.Parse(Console.ReadLine());
            ushort n = ushort.Parse(Console.ReadLine());
            string binary = null;
            int count = 1;
            int dancingBits = 0;
            char previousBit = '\0';

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                binary += Convert.ToString(number, 2);
            }
            foreach (char bit in binary)
            {
                if (count == k)
                {
                    if (previousBit != bit)
                    {
                        dancingBits++;
                        count = 1;
                    }
                    else
                    {
                        count = k + 1;
                    }

                }

                else if (previousBit == bit)
                {
                    count++;
                }
                else if (previousBit != bit)
                {
                    count = 1;
                }
                previousBit = bit;
            }

            if (count == k)
            {
                dancingBits++;
            }
            Console.WriteLine(dancingBits);
        }
    }
}