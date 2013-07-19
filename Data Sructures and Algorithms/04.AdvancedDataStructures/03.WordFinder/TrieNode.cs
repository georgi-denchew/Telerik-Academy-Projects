namespace _03.WordFinder
{
    using System;
    using System.Linq;

    public class TrieNode
    {
        private const int LettersCount = 26;
        private int wordsCount;
        private int prefixesCount;
        private readonly TrieNode[] children;

        public TrieNode()
        {
            this.children = new TrieNode[LettersCount];
            this.wordsCount = 0;
            this.prefixesCount = 0;
        }

        public TrieNode Addword(TrieNode node, string word)
        {
            return this.Addword(node, word, 0);
        }

        public void CalculateOccurrances(TrieNode node, string word)
        {
            CalculateOccurances(node, word, 0);
        }

        public int CountWords(TrieNode node, string word)
        {
            return this.CountWords(node, word, 0);
        }

        public int CountPrefixes(TrieNode node, string word)
        {
            return this.CountPrefixes(node, word, 0);
        }

        private int CountPrefixes(TrieNode node, string word, int currentIndex)
        {
            if (word.Length == currentIndex)
            {
                return node.prefixesCount;
            }
            else
            {
                int nextIndex = word[currentIndex] - 'a';
                currentIndex++;

                if (node.children[nextIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountPrefixes(node.children[nextIndex], word, currentIndex);
                }
            }
        }

        private int CountWords(TrieNode node, string word, int currentIndex)
        {
            if (word.Length == currentIndex)
            {
                return node.wordsCount;
            }
            else
            {
                int nextIndex = word[currentIndex] - 'a';
                currentIndex++;

                if (node.children[nextIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountWords(node.children[nextIndex], word, currentIndex);
                }
            }
        }

        private void CalculateOccurances(TrieNode node, string word, int currentIndex)
        {
            if (word.Length == currentIndex)
            {
                node.wordsCount++;
            }
            else
            {
                int nextIndex = word[currentIndex] - 'a';
                currentIndex++;
                node.prefixesCount++;

                if (node.children[nextIndex] == null)
                {
                    return;
                }
                else
                {
                    CalculateOccurances(node.children[nextIndex], word, currentIndex);
                }
            }
        }

        private TrieNode Addword(TrieNode node, string word, int currentIndex)
        {
            if (word.Length != currentIndex)
            {
                node.prefixesCount++;

                int index = word[currentIndex] - 'a';
                currentIndex++;

                if (node.children[index] == null)
                {
                    node.children[index] = new TrieNode();
                }

                node.children[index] = Addword(node.children[index], word, currentIndex);
            }

            return node;
        }
    }
}
