using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MaximalElementInPortionOfArray
{
    class Program
    {
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void Change(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        static int MinOrMax(int[] arr, int

        static void SortType(int[] arr, bool descending = false)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Change(arr, i, MaxElement(arr, i, descending));
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 2, 8, 4, 5, 6 };
        }
    }
}