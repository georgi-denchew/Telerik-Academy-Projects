using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _13.WordReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "C# is not C++, not PHP and not Delphi!";
            string[] words = Regex.Split(text, @"(\s)|!");
            Array.Reverse(words);
            Console.WriteLine(text);
            Console.WriteLine();

            foreach (string word in words)
            {
                Console.Write(word);
            }
            Console.Write("!");
            Console.WriteLine();
        }
    }
}
