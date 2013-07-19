namespace _03.CountFileWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class WordsCounter
    {
        private StreamReader reader;
        private static char[] SplitSymbols = { ',', '.', ' ', '?', '!', ';', '-', '�' };
        private Dictionary<string, int> countedWords;
        private List<KeyValuePair<string, int>> sortedWords;

        public WordsCounter(string filePath)
        {            
            this.reader = new StreamReader(filePath);
            this.CountWords();
        }

        public void PrintWords()
        {
            for (int i = 0; i < this.sortedWords.Count; i++)
            {
                Console.WriteLine("{0} -> {1} times", this.sortedWords[i].Key, this.sortedWords[i].Value);
            }
        }

        private void CountWords()
        {
            string fileContent = this.ReadFile();

            string[] words = fileContent.Split(SplitSymbols, StringSplitOptions.RemoveEmptyEntries);

            this.countedWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();

                if (this.countedWords.ContainsKey(word))
                {
                    this.countedWords[word]++;
                }
                else
                {
                    this.countedWords.Add(word, 1);
                }
            }

            this.SortWords();
        }

        private void SortWords()
        {
            this.sortedWords = countedWords.ToList();

            sortedWords.Sort((x, y) => x.Value.CompareTo(y.Value));
        }

        private string ReadFile()
        {
            StringBuilder fileContent = new StringBuilder();
            
            using (this.reader)
            {
                string line = this.reader.ReadLine();

                while (line != null)
                {
                    fileContent.AppendLine(line);
                    line = this.reader.ReadLine();
                }
            }

            string result = fileContent.ToString();
            result.Trim();
            result = result.Replace("\r\n", string.Empty);

            return result;
        }
    }
}
