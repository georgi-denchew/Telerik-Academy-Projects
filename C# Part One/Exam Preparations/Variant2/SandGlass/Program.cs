using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandGlass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n % 2 != 0)
            {
                for (decimal i = 1; i <= (n + 1) / 2; i++)
                {
                    for (decimal j = n; j > 0; j--)
                    {
                        if (i == 1)
                        {
                            Console.Write("*");
                        }

                        else
                        {
                            if (j > n - i + 1 || j < i)
                            {
                                Console.Write(".");
                            }

                            else
                            {
                                Console.Write("*");
                            }
                        }
                    }
                    Console.WriteLine();
                }
                for (decimal i = 1; i <= (n - 1) / 2; i++)
                {
                    for (decimal j = n; j > 0; j--)
                    {
                        if (i == (n - 1) / 2)
                        {
                            Console.Write("*");
                        }

                        else
                        {
                            if (j - 1 - (2 * i) > n - j || j <= ((n - 1) / 2) - i)
                            {
                                Console.Write(".");
                            }

                            else
                            {
                                Console.Write("*");
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
