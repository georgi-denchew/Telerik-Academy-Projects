using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.kElementsFromOneToN
{
    class Program
    {
        static int N = int.Parse(Console.ReadLine());
        static int K = int.Parse(Console.ReadLine());

        static void Variations(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                PrintArr(arr);
            }

            else
            {
                for (int i = 1; i <= N; i++)
                {
                    arr[index] = i;
                    Variations(arr, index + 1);
                }
            }
        }

        static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] variations = new int[K];
            Variations(variations, 0);
        }
    }
}
