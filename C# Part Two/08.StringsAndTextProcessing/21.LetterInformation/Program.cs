using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21.LetterInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "The quick brown fox jumps over the lazy dog.";
            int[] values = new int['z' - 'a' + 1];

            foreach (char ch in text.ToLower())
            {
                if ('a' <= ch && ch <= 'z')
                {
                    values[ch - 'a']++;
                }
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != 0)
                {
                    Console.WriteLine("{0} : {1}", (char)(i + 'a'), values[i]);
                }
            }
        }
    }
}

