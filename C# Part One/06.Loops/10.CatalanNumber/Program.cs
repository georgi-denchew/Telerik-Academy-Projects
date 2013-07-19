using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CatalanNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates the Nth Catalan number by given N");
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            int n2 = n * 2;
            int nAddOne = n + 1;
            int x = 1;
            int y = 1;
            int z = 1;
            if (n >= 0)
            {
                while (n2 > 1)
                {
                    x = x * n2;
                    n2--;
                }
                while (nAddOne > 1)
                {
                    y = y * nAddOne;
                    nAddOne--;
                }
                while (n > 1)
                {
                    z = z * n;
                    n--;
                }
                Console.WriteLine("The Catalan number is: {0}", x / (y * z));
            }
        }
    }
}
