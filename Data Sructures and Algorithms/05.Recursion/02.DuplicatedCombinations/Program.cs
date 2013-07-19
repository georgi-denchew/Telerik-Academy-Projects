using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DuplicatedCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 1;
            Console.Write("Enter ending number: ");
            int endNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter combination length: ");
            int length = int.Parse(Console.ReadLine());

            int[] array = new int[length];
            int currentIndex = 0;
            
            GenerateCombinations(currentIndex, array, startNumber, endNumber);
        }

        private static void GenerateCombinations(int currentIndex, int[] array, int startNumber, int endNumber)
        {
            if (currentIndex >= array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
                return;
            }

            for (int i = startNumber; i <= endNumber; i++)
            {
                array[currentIndex] = i;
                GenerateCombinations(currentIndex + 1, array, i, endNumber);
            }
        }
    }
}
