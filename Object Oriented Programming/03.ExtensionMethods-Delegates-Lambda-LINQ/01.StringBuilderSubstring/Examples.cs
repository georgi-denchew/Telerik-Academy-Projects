using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderSubstring
{
    //Implement an extension method Substring(int index, int length) 
    //for the class StringBuilder that returns new StringBuilder and 
    //has the same functionality as Substring in the class String.

    class Examples
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder("Genius is one percent inspiration and ninety-nine percent perspiration.");
            Console.WriteLine(input.Substring(7));
            Console.WriteLine();
            Console.WriteLine(input.Substring(0, 6));
        }
    }
}
