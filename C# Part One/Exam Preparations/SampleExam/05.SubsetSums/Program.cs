using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SubsetSums
{
    class Program
    {
        static void Main(string[] args)
        {
            long s = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            long n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16;
            n1 = n2 = n3 = n4 = n5 = n6 = n7 = n8 = n9 = n10 = n11 = n12 = n13 = n14 = n15 = n16 = 0L;

            if (n >= 1 && n <= 16 && s >= -21392000000000 && s <= 21392000000000)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == 1) n1 = long.Parse(Console.ReadLine());
                    if (i == 2) n2 = long.Parse(Console.ReadLine());
                    if (i == 3) n3 = long.Parse(Console.ReadLine());
                    if (i == 4) n4 = long.Parse(Console.ReadLine());
                    if (i == 5) n5 = long.Parse(Console.ReadLine());
                    if (i == 6) n6 = long.Parse(Console.ReadLine());
                    if (i == 7) n7 = long.Parse(Console.ReadLine());
                    if (i == 8) n8 = long.Parse(Console.ReadLine());
                    if (i == 9) n9 = long.Parse(Console.ReadLine());
                    if (i == 10) n10 = long.Parse(Console.ReadLine());
                    if (i == 11) n11 = long.Parse(Console.ReadLine());
                    if (i == 12) n12 = long.Parse(Console.ReadLine());
                    if (i == 13) n13 = long.Parse(Console.ReadLine());
                    if (i == 14) n14 = long.Parse(Console.ReadLine());
                    if (i == 15) n15 = long.Parse(Console.ReadLine());
                    if (i == 16) n16 = long.Parse(Console.ReadLine());
                }

                int maxi = (int)Math.Pow(2, n) - 1;
                for (int i = 1; i <= maxi; i++)
                {
                    long sum = 0;
                    for (int j = 1; j <= n; j++)
                    {
                        if (((i >> (j - 1)) & 1) == 1)
                        {
                            if (j == 1) sum += n1;
                            if (j == 2) sum += n2;
                            if (j == 3) sum += n3;
                            if (j == 4) sum += n4;
                            if (j == 5) sum += n5;
                            if (j == 6) sum += n6;
                            if (j == 7) sum += n7;
                            if (j == 8) sum += n8;
                            if (j == 9) sum += n9;
                            if (j == 10) sum += n10;
                            if (j == 11) sum += n11;
                            if (j == 12) sum += n12;
                            if (j == 13) sum += n13;
                            if (j == 14) sum += n14;
                            if (j == 15) sum += n15;
                            if (j == 16) sum += n16;
                        }
                    }
                    if (sum == s)
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}