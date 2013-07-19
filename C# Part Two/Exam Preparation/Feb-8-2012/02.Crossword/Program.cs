using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Crossword
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();

            for (int i = 0; i < n + n; i++)
            {
                string word = Console.ReadLine();
                words.Add(word);
            }
            CrosswordGenerator crosswordGenerator = new CrosswordGenerator(words, n);
            string[] crossword = crosswordGenerator.GenerateCrossword();
            if (crossword == null)
            {
                Console.WriteLine("NO SOLUTION!");
            }
            else
            {
                foreach (string line in crossword)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }

    class CrosswordGenerator
    {
        readonly List<string> words;
        readonly int size;

        public CrosswordGenerator(List<string> words, int size)
        {
            this.words = words.OrderBy(x => x).ToList();
            this.size = size;
        }

        string[] currentCrossword;
        bool solutionFound = false;
        char[] ch;

        private void Solve(int currentIndex)
        {
            if (currentIndex == size)
            {
                bool isOK = true;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        ch[j] = currentCrossword[j][i];
                    }
                    if (!words.Contains(new string(ch)))
                    {
                        isOK = false;
                        break;
                    }
                }

                if (isOK)
                {
                    solutionFound = true;
                }
                return;
            }
            for (int i = 0; i < words.Count; i++)
            {
                currentCrossword[currentIndex] = words[i];
                Solve(currentIndex + 1);
                if (solutionFound)
                {
                    return;
                }
            }
        }
        public string[] GenerateCrossword()
        {
            currentCrossword = new string[size];
            ch = new char[size];
            Solve(0);
            if (solutionFound)
            {
                return currentCrossword;
            }
            else
            {
                return null;
            }
        }
    }
}
