using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.BinaryRepresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter short number: ");
            short n = short.Parse(Console.ReadLine());
            short sign = n;

            if (sign <= 0)
            {
                n = (short)(n + 1);
            }

            Console.WriteLine("Binary representation of the number:");

            for (int i = 15; i >= 0; i--)
            {
                short rep = (short)Math.Pow(2, i);
                short dig = (short)(n / rep);
                n = (short)(n % rep);

                if (sign < 0)
                {
                    Console.Write(1 + dig);

                }

                else
                {
                    Console.Write(dig);
                }
            }
        }
    }
}
