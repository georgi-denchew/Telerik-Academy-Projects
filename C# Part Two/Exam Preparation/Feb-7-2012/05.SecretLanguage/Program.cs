using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.SecretLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            string words = Console.ReadLine();
            string[] validWords = words.Split(new char[] {' ', ',', '\"'}, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(Decompose(sentence, validWords));
        }
        static int Decompose(string sentence, string[] validWords)
        {
            int n = sentence.Length;
            int m = validWords.Length;
            int[] minValue = new int[n + 1];
            minValue[0] = 0;
            for (int i = 1; i < minValue.Length; i++)
            {
                minValue[i] = 999999;
            }

            string[] validSorted = new string[m];

            for (int i = 0; i < m; i++)
            {
                char[] c = validWords[i].ToCharArray();
                Array.Sort(c);
                validSorted[i] = new string(c);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (validWords[j].Length <= i + 1)
                    {
                        string s = sentence.Substring(i + 1 - validWords[j].Length, validWords[j].Length);
                        char[] c = s.ToCharArray();
                        Array.Sort(c);
                        string sSorted = new string(c);

                        if (sSorted == validSorted[j])
                        {
                            int cost = 0;

                            for (int k = 0; k < sSorted.Length; k++)
                            {
                                if (s[k] != validWords[j][k]) cost++;
                            }

                            minValue[i + 1] = Math.Min(minValue[i + 1], minValue[i + 1 - validWords[j].Length] + cost);
                        }
                    }
                }
            }
            return minValue[n] < 999999 ? minValue[n] : -1;
        }
    }
}
