using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.IndexOfLettersInAWord
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm',
                               'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z'};

            Console.Write("Enter the word here: ");
            string word = Console.ReadLine();

            Console.WriteLine("The indexes of the letters are:");
            foreach (char letter in word)
            {
                Console.WriteLine(Array.IndexOf(letters, letter));
            }
        }
    }
}
