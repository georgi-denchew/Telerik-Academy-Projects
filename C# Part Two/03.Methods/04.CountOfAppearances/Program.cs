using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountOfAppearances
{
    class Program
    {
        static int Count(int[] arr, int number)
        {
            int count = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i] == number)
                {
                    count++;
                }
            }

            return count;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter array length here: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine("Enter array values here:");

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the number you want to check here: ");
            int number = int.Parse(Console.ReadLine());

            int count = Count(arr, number);
            Console.WriteLine();
            Console.WriteLine("The number {0} appears {1} times", number, count);
        }
    }
}
