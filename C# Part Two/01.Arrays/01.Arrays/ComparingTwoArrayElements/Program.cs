using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingTwoArrayElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the arrays here: ");
            int arraysLength = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[] firstArray = new int[arraysLength];
            int[] secondArray = new int[arraysLength];

            Console.WriteLine("Enter the values of the first array here: ");

            for (int i = 0; i < arraysLength; i++)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the values of the second array here: ");

            for (int i = 0; i < arraysLength; i++)
            {
                secondArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            for (int i = 0; i < arraysLength; i++)
            {
                Console.WriteLine(Math.Max(firstArray[i], secondArray[i]));
            }
        }
    }
}
