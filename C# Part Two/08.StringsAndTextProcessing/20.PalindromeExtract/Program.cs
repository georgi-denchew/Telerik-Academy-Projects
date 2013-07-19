using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.PalindromeExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abba? lamal exe, exa. lemal! abab";
            string[] words = text.Split(' ', ',', '?', '.', '!');
            
            foreach (string word in words)
            {
                if (word != "")
                {
                    StringBuilder reverse = new StringBuilder(word.Length);

                    for (int i = word.Length - 1; i >= 0; i--)
                    {
                        reverse.Append((char)word[i]);
                    }

                    if (word == reverse.ToString())
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
