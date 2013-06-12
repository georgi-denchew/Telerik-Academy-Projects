namespace _04.LongestSubseqquenceEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using _00.Methods;

    class Example
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Enter numbers, each on a new line.{0}Enter an empty string to finish.",
                Environment.NewLine);

            List<int> sequence = new List<int>();
            string input = string.Empty;
            int parsedNumber = 0;
            bool parseSuccessful = false;

            // Method ParseInput can be found in the 00.Methods project
            Methods.ParseInput(sequence, ref input, ref parsedNumber, ref parseSuccessful);

            List<int> equalNumberSubsequence = EqualNumbersSubsequence(sequence);

            // Method PrintSequence can be found in the 00.Methods project
            Methods.PrintSequence(equalNumberSubsequence);
        }

        public static List<int> EqualNumbersSubsequence(List<int> sequence)
        {
            if (sequence.Count <= 1)
            {
                return sequence;
            }

            int maximalOccurences = 1;
            int currentOccurences = 1;
            int currentNumber;
            int mostFrequentNumber = 0;

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                currentNumber = sequence[i];

                if (currentNumber == sequence[i + 1])
                {
                    currentOccurences++;

                    if (currentOccurences >= maximalOccurences)
                    {
                        maximalOccurences = currentOccurences;
                        mostFrequentNumber = currentNumber;
                    }
                }
                else
                {
                    currentOccurences = 1;
                }
            }

            List<int> result = new List<int>();

            if (maximalOccurences > 1)
            {
                for (int i = 0; i < maximalOccurences; i++)
                {
                    result.Add(mostFrequentNumber);
                } 
            }

            return result;
        }
    }
}
