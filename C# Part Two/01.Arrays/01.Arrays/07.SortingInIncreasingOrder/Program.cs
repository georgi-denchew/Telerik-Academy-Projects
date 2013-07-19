using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SortingInIncreasingOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            int[] sortedArray = new int[length];
            int smallest = int.MaxValue;
            int position = 0;

            Console.WriteLine();
            Console.WriteLine("Enter the numbers in the array here: ");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("The array with sorted numbers is: ");
            for (int i = 0; i < length; i++)
            {
                smallest = int.MaxValue;
                for (int j = 0; j < length; j++)
                {
                    if (arr[j] < smallest)
                    {
                        position = j;
                        smallest = arr[j];
                    }
                }
                arr[position] = int.MaxValue;
                sortedArray[i] = smallest;
                Console.Write(sortedArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
