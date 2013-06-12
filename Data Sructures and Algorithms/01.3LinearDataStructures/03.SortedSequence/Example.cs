namespace _03.SortedSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

            List<int> sortedSequence = Quicksort(sequence);

            // Method PrintSequence can be found in the 00.Methods project
            Methods.PrintSequence(sortedSequence);
        }

        public static List<int> Quicksort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            int middleIndex = list.Count / 2;
            int pivot = list[middleIndex];

            list.RemoveAt(middleIndex);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= pivot)
                {
                    less.Add(list[i]);
                }
                else
                {
                    greater.Add(list[i]);
                }
            }

            less = Quicksort(less);
            less.Add(pivot);

            return less.Concat(Quicksort(greater)).ToList();
        }
    }
}
