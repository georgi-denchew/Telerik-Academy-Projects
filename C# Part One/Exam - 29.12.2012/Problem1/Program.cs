using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            long q1 = long.Parse(Console.ReadLine());
            long q2 = long.Parse(Console.ReadLine());
            long q3 = long.Parse(Console.ReadLine());
            long q4 = long.Parse(Console.ReadLine());
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int length = (r * c) - 1;
            long qN = q1 + q2 + q3 + q4;
            int count = 4;
            if (r >= 1 && r <= 20 && c >= 4 && c <= 20)
            {
                Console.Write(q1 + " " + q2 + " " + q3 + " " + q4);
                if (count == c)
                {
                    Console.WriteLine();
                    count = 0;
                }
                else
                {
                    Console.Write(" ");
                }
                for (int numbers = 4; numbers <= length; numbers++)
                {
                    
                    qN = q1 + q2 + q3 + q4;
                    count++;
                    if (count == c)
                    {
                        Console.Write(qN);
                        Console.WriteLine();
                        count = 0;
                    }
                    
                    else
                    {
                    Console.Write(qN + " ");
                    }
                    
                    q1 = q2;
                    q2 = q3;
                    q3 = q4;
                    q4 = qN;
                }
            }
        }
    }
}
