using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LeastMajorityMutliple
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            int leastMajority = 1;
            int count = 0;

            while (true)
            {
                if (leastMajority % a == 0)
                {
                    count++;
                }
                
                if (leastMajority % b == 0)
                {
                    count++;
                }
                
                if (leastMajority % c == 0)
                {
                    count++;
                }
                
                if (leastMajority % d == 0)
                {
                    count++;
                }
                
                if (leastMajority % e == 0)
                {
                    count++;
                }

                if (count >= 3)
                {
                    Console.WriteLine(leastMajority);
                    break;
                }

                leastMajority++;
                count = 0;
            }
        }
    }
}
