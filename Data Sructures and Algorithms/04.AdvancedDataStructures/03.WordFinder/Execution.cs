using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace _03.WordFinder
{
    class Execution
    {
        static void Main(string[] args)
        {
            TrieNode trie = new TrieNode();
            Dictionary<string, int> countedWords = new Dictionary<string, int>();
            
            string file = "words.txt";
            var allWords = FindAllWords(file);

            LinkedList<string> searchedWords = new LinkedList<string>();

            for (int i = 0; i < 20; i++)
            {
                searchedWords.AddLast(allWords[i].ToString());
            }

            FillDictionary(searchedWords, countedWords);
            
            FillTrie(trie, searchedWords);
            CountOccurrances(trie, allWords);
            CountOccurrances(countedWords, allWords);

            foreach (var word in countedWords)
            {
                Console.WriteLine("{0} {1} times", word.Key, word.Value);
            }
        }

        private static void CountOccurrances(Dictionary<string, int> countedWords, MatchCollection allWords)
        {
            foreach (var word in allWords)
            {
                string stringedWord = word.ToString();

                if (countedWords.ContainsKey(stringedWord))
                {
                    countedWords[stringedWord]++;
                }
            }
        }

        private static void CountOccurrances(TrieNode trie, MatchCollection allWords)
        {
            foreach (var word in allWords)
            {
                trie.CalculateOccurrances(trie, word.ToString());
            }
        }

        private static void FillTrie(TrieNode trie, LinkedList<string> searchedWords)
        {
            foreach (var word in searchedWords)
            {
                trie.Addword(trie, word);
            }
        }

        private static void FillDictionary(LinkedList<string> searchedWords, Dictionary<string, int> countedWords)
        {
            foreach (var searchedWord in searchedWords)
            {
                string word = searchedWord;

                if (!countedWords.ContainsKey(word))
                {
                    countedWords.Add(word, 0);
                }
            }
        }

        private static MatchCollection FindAllWords(string file)
        {
            StreamReader reader = new StreamReader(file);
            string input = string.Empty;
            
            using (reader)
            {
               input = reader.ReadToEnd().ToLower();
            }

            MatchCollection allWords = Regex.Matches(input, @"[a-zA-Z]+");

            return allWords;
        }
    }
}
