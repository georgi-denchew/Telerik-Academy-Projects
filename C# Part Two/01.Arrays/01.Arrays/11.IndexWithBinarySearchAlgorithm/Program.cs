using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.IndexWithBinarySearchAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array length here:");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            Console.WriteLine("Enter element value here:");
            int n = int.Parse(Console.ReadLine());
            int max = arr.Length - 1;
            int min = 0;
            int mid = 0;

            Console.WriteLine("Enter array numbers here:");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);

            while (max >= min)
            {
                mid = (max + min) / 2;

                if (n > arr[mid])
                {
                    min = mid;
                }

                else if (n < arr[mid])
                {
                    max = mid;
                }

                else
                {
                    break;
                }
            }

            Console.WriteLine(mid);
        }
    }
}
