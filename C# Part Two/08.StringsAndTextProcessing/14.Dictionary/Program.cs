using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word: ");
            string input = Console.ReadLine();
            string dotNet = ".NET";
            string dotNetExpl = "platform for applications from Microsoft";
            string clr = "CLR";
            string clrExpl = "managed execution environment for .NET";
            string nSpace = "namespace";
            string nSpaceExpl = "hierarchical organization of classes";

            if (string.Compare(input, dotNet) == 0)
            {
                Console.WriteLine(dotNetExpl);
            }

            if (string.Compare(input, clr) == 0)
            {
                Console.WriteLine(clrExpl);
            }

            if (string.Compare(input, nSpace) == 0)
            {
                Console.WriteLine(nSpaceExpl);
            }
        }
    }
}