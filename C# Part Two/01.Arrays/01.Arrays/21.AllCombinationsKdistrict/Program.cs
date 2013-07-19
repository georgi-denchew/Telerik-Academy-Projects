using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.AllCombinationsKdistrict
{
    class Program
    {
        static int N = int.Parse(Console.ReadLine());
        static int K = int.Parse(Console.ReadLine());

        static void Combinations(int[] arr, int index, int currNumber)
        {
            if (index == arr.Length)
            {
                PrintArr(arr);
            }

            else
            {
                for (int i = currNumber; i <= N; i++)
                {
                    arr[index] = i;
                    Combinations(arr, index + 1, i + 1);
                }
            }
        }

        static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = new int[K];
            Combinations(arr, 0, 1);
        }
    }
}
