using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CalculatingN_DividedByK_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates N!/K! for given N and K (1<K<N)");
            Console.Write("Enter N here: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K here: ");
            int k = int.Parse(Console.ReadLine());
            int temp1 = 1;
            int temp2 = 1;

            if (1 < k && k < n)
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
                Console.WriteLine("The result is: {0}", temp1 / temp2);
            }
            else
            {
                Console.WriteLine("Please enter N and K that are under the condition 1<K<N");
            }

        }
    }
}
