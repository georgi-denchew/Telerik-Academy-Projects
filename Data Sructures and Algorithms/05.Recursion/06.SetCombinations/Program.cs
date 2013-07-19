namespace _06.SetCombinations
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int length = 2;
            string[] set = new string[] { "test", "rock", "fun" };
            string[] subset = new string[length];
            bool[] visited = new bool[set.Length];
            int currentIndex = 0;
            int startIndex = 0;
            int endIndex = length;

            GenerateCombinations(currentIndex, startIndex, endIndex, set, subset, visited);
        }

        private static void GenerateCombinations(int currentIndex, int startIndex, int endIndex, string[] set, string[] subset, bool[] visited)
        {
            if (currentIndex >= subset.Length)
            {
                Console.WriteLine(string.Join(", ", subset));
                return;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                subset[currentIndex] = set[i];
                GenerateCombinations(currentIndex + 1, i + 1, endIndex, set, subset, visited);
            }
        }
    }
}
