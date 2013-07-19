namespace _03.CountFileWords
{
    using System;
    using System.Linq;

    class Example
    {
        static void Main(string[] args)
        {
            // File can be found in the directory: bin/debug
            string filePath = "words.txt";
            WordsCounter counter = new WordsCounter(filePath);

            counter.PrintWords();
        }
    }
}
