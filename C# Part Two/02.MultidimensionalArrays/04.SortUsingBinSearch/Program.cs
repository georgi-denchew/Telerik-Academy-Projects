using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortUsingBinSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer K here: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Enter length N here: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}]", i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);

            Console.WriteLine("Sorted array:");

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            int index = Array.BinarySearch(arr, k);

            if (index == arr.Length)
            {
                Console.WriteLine("The largest number, smaller than K is: {0}", arr[arr.Length -1]);
            }

            if (index == -1)
            {
                Console.WriteLine("All the elements in the array are larger than the number K");
            }

            else if (index >= 0)
            {
                Console.WriteLine("The the number, that equals K is at position {0} in the sorted array and the number is: {1}", index, arr[index]);
            }

            else
            {
                index = ~index - 1;
                Console.WriteLine("The largest number, smaller than K is {0}", arr[index]);
            }
        }
    }
}
