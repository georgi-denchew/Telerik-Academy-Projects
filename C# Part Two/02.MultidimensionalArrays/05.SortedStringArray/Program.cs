using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SortedStringArray
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter number of of strings in the array here: ");
            int n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];

            Console.WriteLine("Enter strings for each element here: ");

            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}]: ",i);
                arr[i] = Console.ReadLine();
            }

            arr = arr.OrderBy(x => x.Length).ToArray();
            Console.WriteLine();
            Console.WriteLine("Here's each element on of the sorted array on a new line:");
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
