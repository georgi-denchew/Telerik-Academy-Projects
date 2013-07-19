namespace _01.OccurencesCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            double[] values = new double[9] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            SortedDictionary<double, int> valueCounter = new SortedDictionary<double, int>();

            CountOccurrences(values, valueCounter);

            PrintOccurrences(valueCounter);
        }

        private static void CountOccurrences(double[] values, SortedDictionary<double, int> valueCounter)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (valueCounter.ContainsKey(values[i]))
                {
                    valueCounter[values[i]]++;
                }
                else
                {
                    valueCounter.Add(values[i], 1);
                }
            }
        }

        private static void PrintOccurrences(SortedDictionary<double, int> valueCounter)
        {
            foreach (var counter in valueCounter)
            {
                Console.WriteLine("{0} -> {1} times", counter.Key, counter.Value);
            }
        }
    }
}
