using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.RegexSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Regex.Split("скара-бира", "(-)");
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }
}
