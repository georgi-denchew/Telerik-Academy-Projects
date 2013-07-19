using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter permutation length, starting from 1: ");
            int permutationLength = int.Parse(Console.ReadLine());
            int[] array = new int[permutationLength];
            bool[] visited = new bool[permutationLength];

            int currentIndex = 0;

            GeneratePermutations(currentIndex, permutationLength, array, visited);
        }

        private static void GeneratePermutations(int currentIndex, int permutationLength, int[] array, bool[] visited)
        {
            if (currentIndex >= array.Length)
            {
                Console.WriteLine(string.Join(", ",array));
                return;
            }

            for (int i = 1; i <= permutationLength; i++)
            {
                if (!visited[i - 1])
                {
                    array[currentIndex] = i;
                    visited[i - 1] = true;
                    GeneratePermutations(currentIndex + 1, permutationLength, array, visited);
                    visited[i - 1] = false;
                }
            }
        }
    }
}
