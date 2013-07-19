using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            if ((b == 0 || b == 1) && n >= 1 && n <= 1000)
            {
                for (int i = 1; i <= n; i++)
                {
                    long number = long.Parse(Console.ReadLine());
                    if (number >= 1 && number <= 4000000000 && b== 1)
                    {
                        while (number >= 1)
                        {
                            if (number % 2 == 1)
                            {
                                count++;
                            }
                            number = number / 2;
                        }
                    }
                    if (number >= 1 && number <= 4000000000 && b == 0)
                    {
                        while (number >= 1)
                        {
                            if (number % 2 == 0)
                            {
                                count++;
                            }
                            number = number / 2;
                        }
                    }
                    Console.WriteLine(count);
                    count = 0;
                }
            }
        }
    }
}
