using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n >= 3 && n <= 39)
            {
                for (int i = 1; i <= 1 + n; i++)
                {
                    for (int j = 1; j <= 2 * n; j++)
                    {
                        if (i == 1)
                        {
                            if (j <= n)
                            {
                                Console.Write(".");
                            }

                            else
                            {
                                Console.Write("*");
                            }
                        }

                        else if (i == n + 1)
                        {
                            Console.Write("*");
                        }

                        else
                        {
                            if (j == n - i + 2)
                            {
                                Console.Write("*");
                            }

                            else if (j == 2 * n)
                            {
                                Console.Write("*");
                            }

                            else
                            {
                                Console.Write(".");
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
