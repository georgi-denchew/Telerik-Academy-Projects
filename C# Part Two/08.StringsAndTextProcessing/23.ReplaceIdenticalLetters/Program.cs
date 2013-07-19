using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.ReplaceIdenticalLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "aaaaabbbbbcdddeeeedssaa";
            StringBuilder letters = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    letters.Append((char)(text[i]));
                }
                if (i > 0 && text[i] != text[i - 1])
                {
                    letters.Append((char)(text[i]));
                }
            }

            Console.WriteLine(letters);
        }
    }
}
