using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FirTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n >= 4 && n <= 100)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= 2 * n - 3; j++)
                    {
                        if (i == n)
                        {
                            if (j == n - 1)
                            {
                                Console.Write("*");
                            }

                            else
                            {
                                Console.Write(".");
                            }
                        }
                        else if (j <= n - i - 1)
                        {
                            Console.Write(".");
                        }

                        else if (j >= n + i - 1)
                        {
                            Console.Write(".");
                        }

                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
