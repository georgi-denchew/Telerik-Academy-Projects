namespace _02.MinimumEditDistance
{
    using System;
    using System.Linq;

    class Program
    {
        private const decimal DeleteCost = 0.9m;
        private const decimal InsertCost = 0.8m;
        private const decimal ReplaceCost = 1m;
        private static decimal[,] table;

        static void Main(string[] args)
        {
            string developer = "developer";
            string enveloped = "enveloped";
            string publisher = "publisher";

            decimal example1 = CalculateCost(developer, enveloped);
            Console.WriteLine("Cost for {0} -> {1}: {2}", developer, enveloped, example1);

            decimal example2 = CalculateCost(developer, developer);
            Console.WriteLine("`Cost for {0} -> {1}: {2}", developer, developer, example2);

            decimal example3 = CalculateCost(developer, publisher);
            Console.WriteLine("`Cost for {0} -> {1}: {2}", developer, publisher, example3);
        }

        private static decimal CalculateCost(string inputWord, string outputWord)
        {
            int inputWordLength = inputWord.Length;
            int outputWordLength = outputWord.Length;
            table = new decimal[inputWordLength + 1, outputWordLength + 1];

            for (int i = 0; i <= inputWordLength; i++)
            {
                table[i, 0] = i * DeleteCost;
            }

            for (int i = 0; i <= outputWordLength; i++)
            {
                table[0, i] = i * InsertCost;
            }

            for (int i = 1; i <= inputWordLength; i++)
            {
                for (int j = 1; j <= outputWordLength; j++)
                {
                    decimal cost = inputWord[j - 1] == outputWord[i - 1] ? 0 : ReplaceCost;
                    decimal delete = table[i - 1, j] + DeleteCost;
                    decimal replace = table[i - 1, j - 1] + cost;
                    decimal insert = table[i, j - 1] + InsertCost;

                    table[i, j] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            return table[inputWordLength, outputWordLength];
        }
    }
}
