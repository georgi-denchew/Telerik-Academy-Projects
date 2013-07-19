using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FallDown
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n0 = byte.Parse(Console.ReadLine());
            byte n1 = byte.Parse(Console.ReadLine());
            byte n2 = byte.Parse(Console.ReadLine());
            byte n3 = byte.Parse(Console.ReadLine());
            byte n4 = byte.Parse(Console.ReadLine());
            byte n5 = byte.Parse(Console.ReadLine());
            byte n6 = byte.Parse(Console.ReadLine());
            byte n7 = byte.Parse(Console.ReadLine());
            int byte = 0;
            byte[] numbers = { n7, n6, n5, n4, n3, n2, n1, n0 };
            foreach (byte number in numbers)
            {
                for (int i = 0; i < 32; i++)
                {
                    byte = (1 << i) & number;
                    if ((1 << i) & number != 0)
                    {

                    }
                }
            }
        }
    }
}
