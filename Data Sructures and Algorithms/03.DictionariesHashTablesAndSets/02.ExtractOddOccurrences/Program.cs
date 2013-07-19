namespace _02.ExtractOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = new string[6] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            
            Dictionary<string, int> countedStrings = new Dictionary<string, int>();

            CountOccurences(strings, countedStrings);

            PrintOddOccurrences(countedStrings);
        }

        private static void CountOccurences(string[] strings, Dictionary<string, int> countedStrings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                if (countedStrings.ContainsKey(strings[i]))
                {
                    countedStrings[strings[i]]++;
                }
                else
                {
                    countedStrings.Add(strings[i], 1);
                }
            }
        }

        private static void PrintOddOccurrences(Dictionary<string, int> countedStrings)
        {
            Console.WriteLine("Strings which appear odd number of times:");
            foreach (var countedString in countedStrings)
            {
                if (countedString.Value % 2 != 0)
                {
                    Console.WriteLine("{0} -> {1} times", countedString.Key, countedString.Value);
                }
            }
        }
    }
}
