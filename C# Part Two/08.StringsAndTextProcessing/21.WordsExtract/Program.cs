using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21.WordsExtract
{
    class Program
    {

        static void Main(string[] args)
        {
            string text = "The fox jumps over the dog. The quick brown fox jumps over the lazy dog.";
            string[] words = text.Split();

            foreach (string word in words)
            {

                MatchCollection matches = Regex.Matches(text, word, RegexOptions.IgnoreCase);
                Console.WriteLine("{0} - {1} times", word, matches.Count);
            }
        }
    }
}