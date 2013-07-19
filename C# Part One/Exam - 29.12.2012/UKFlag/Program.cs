using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            if (n >= 5 && n <= 79 && n % 2 != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (j == i && (i != (n + 1) / 2 && j != (n + 1) / 2))
                        {
                            Console.Write(@"\");
                        }

                        else if (j == (n + 1) / 2 && i != (n + 1) / 2)
                        {
                            Console.Write("|");
                        }

                        else if (j == n - i + 1 && j != (n + 1) / 2 && n != (n + 1) / 2)
                        {
                            Console.Write("/");
                        }

                        else if (i == (n + 1) / 2)
                        {
                            if (j == (n + 1) / 2)
                            {
                                Console.Write("*");
                            }

                            else
                            {
                                Console.Write("-");
                            }
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
