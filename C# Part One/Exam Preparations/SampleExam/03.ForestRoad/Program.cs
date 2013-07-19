using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ForestRoad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n >= 2 && n <= 79)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int a = 0; a < n; a++)
                    {
                        if (i == a)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }
                for (int j = n - 1; j > 0; j--)
                {
                    for (int b = 1; b < n + 1; b++)
                    {
                        if (b == j)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}