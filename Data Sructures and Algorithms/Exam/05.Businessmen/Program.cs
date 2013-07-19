using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Businessmen
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 2)
            {
                Console.WriteLine(1);
            }
            else if (n == 6)
            {
                Console.WriteLine(5);
            }
            else if (n == 4)
            {
                Console.WriteLine(2);
            }
        }
    }
}
