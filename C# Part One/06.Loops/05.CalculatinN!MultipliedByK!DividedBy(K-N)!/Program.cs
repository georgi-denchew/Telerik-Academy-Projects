using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculatinN_MultipliedByK_DividedBy_K_N__
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates N!*K!/(K-N)! for given N and K (1<N<K)");
            Console.Write("Enter K here: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            int temp1 = 1;
            int temp2 = 1;
            int temp3 = 1;
            int m = k - n;
            if (1 < n && n < k)
            {
                while (n > 1)
                {
                    temp1 = temp1 * n;
                    n--;
                }
                while (k > 1)
                {
                    temp2 = temp2 * k;
                    k--;
                }
                while (m > 1)
                {
                    temp3 = temp3 * m;
                    m--;
                }
                Console.WriteLine("The result is: {0}", temp1 * temp2 / temp3);
            }
        }
    }
}
