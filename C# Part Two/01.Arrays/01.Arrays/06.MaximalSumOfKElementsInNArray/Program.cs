using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaximalSumOfKElementsInNArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter K number here: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Enter N number here: ");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxSum = 0;
            int[] arr = new int[n];

            Console.WriteLine();
            Console.WriteLine("Enter the elements for the N array here: ");

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i <= n - k; i++)
            {
                sum = 0;
                for (int a = 0; a < k; a++)
                {
                    sum = sum + arr[i + a];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("The maximal sum of {0} elements is: {1}", k, maxSum);
        }
    }
}
