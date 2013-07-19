using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IsoscaleTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int a = 169;
            byte br = 3;
            for (int i = 0; i < 3; i++)
            {
                for (int t = 0; t < br; t++) Console.Write(" ");
                for (int j = 0; j <= i; j++)
                {
                    Console.Write((char)a);
                }
                for (int j = 0; j <= i - 1; j++)
                {
                    Console.Write((char)a);
                }
                br--;
                Console.WriteLine();
            }
        }
    }
}
