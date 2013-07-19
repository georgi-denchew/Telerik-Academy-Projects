namespace _05.Variations
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of subsets: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter subset length: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter the the words from the set, separated by a single space: ");
            string wordset = Console.ReadLine();

            string[] set = wordset.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] subset = new string[length];
            int currentIndex = 0;

            GenerateVariations(currentIndex, length, subset, set);
        }

        private static void GenerateVariations(int currentIndex, int length, string[] subset, string[] set)
        {
            if (currentIndex >= subset.Length)
            {
                Console.WriteLine(string.Join(", ", subset));
                return;
            }

            for (int i = 0; i <= length; i++)
            {
                subset[currentIndex] = set[i];
                GenerateVariations(currentIndex + 1, 2, subset, set);
            }
        }
    }
}
