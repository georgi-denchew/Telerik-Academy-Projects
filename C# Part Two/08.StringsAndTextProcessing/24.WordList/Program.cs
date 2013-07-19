using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _24.WordList
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "The quick brown fox jumps over the lazy dog.";
            string[] words = Regex.Split(text, @"[\s|.|,|!|?]");

            List<string> ordered = new List<string>();

            foreach (string word in words)
            {
                ordered.Add(word);
            }

            ordered.Sort();

            foreach (string orderedWord in ordered)
            {
                if (orderedWord != "")
                {
                    Console.WriteLine(orderedWord);
                }
            }
        }
    }
}
