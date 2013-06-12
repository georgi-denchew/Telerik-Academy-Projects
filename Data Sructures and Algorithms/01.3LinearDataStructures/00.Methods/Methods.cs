using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Methods
{
    public static class Methods
    {
        public static void PrintSequence(List<int> sortedSequence)
        {
            for (int i = 0; i < sortedSequence.Count; i++)
            {
                Console.WriteLine(sortedSequence[i]);
            }
        }

        public static void ParseInput(List<int> sequence, ref string input, ref int parsedNumber, ref bool parseSuccessful)
        {
            while (true)
            {
                input = Console.ReadLine();

                if (input == null || input == string.Empty)
                {
                    break;
                }

                parseSuccessful = int.TryParse(input, out parsedNumber);

                if (parseSuccessful)
                {
                    sequence.Add(parsedNumber);
                }
            }
        }

        public static Dictionary<int, int> CountOccurences(int[] array)
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();
            bool containsKey = false;

            for (int i = 0; i < array.Length; i++)
            {
                containsKey = occurences.ContainsKey(array[i]);

                if (!containsKey)
                {
                    occurences.Add(array[i], 0);
                }

                occurences[array[i]]++;
            }

            occurences.OrderBy(x => x.Key);

            return occurences;
        }

        public static int FindMajorant(int[] array)
        {
            Dictionary<int, int> allOccurences = Methods.CountOccurences(array);
            
            bool hasMajorant = allOccurences.ContainsValue(array.Length / 2 + 1);
            int result;

            if (hasMajorant)
            {
                result = allOccurences.Single(x => x.Value == array.Length / 2 + 1).Key;
            }
            else
            {
                result = -1;
            }

            return result;
        }
    }
}
