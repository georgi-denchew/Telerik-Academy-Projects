using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SequenceOfMaximalSumInGivenArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            int sum = 0;
            int maxSum = 0;
            int position = 0;
            Console.WriteLine();
            Console.WriteLine("Enter numbers in the array here: ");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (i >= 3)
                {
                    sum = arr[i] + arr[i - 1] + arr[i - 2] + arr[i - 3];
                }

                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        position = i;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("The sequence of the maximal sum is: {0}, {1}, {2}, {3}", arr[position - 3], arr[position - 2], arr[position - 1], arr[position]);
        }
    }
}
