using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _04.RecoverMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            OrderedDictionary<char, string> orderedRelations = new OrderedDictionary<char, string>();

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                orderedRelations.Add(line[0], line.Substring(1));
            }

            Console.WriteLine("Aa");
        }
    }
}
