namespace _07.EachNumberOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _00.Methods;

    class Example
    {
        static void Main(string[] args)
        {
            int[] array = new int[9] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            // Method CountOccurences can be found in the project 00.Methods
            Dictionary<int, int> countedOccurences =
               Methods.CountOccurences(array);

            foreach (var number in countedOccurences.OrderBy(x => x.Key))
            {
                Console.WriteLine(
                    "{0} --> {1} times",
                    number.Key,
                    number.Value);
            }
        }
    }
}
