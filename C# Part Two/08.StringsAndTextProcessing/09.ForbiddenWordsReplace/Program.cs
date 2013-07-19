using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.ForbiddenWordsReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string pattern = @"PHP|Microsoft|CLR";

            foreach (Match match in Regex.Matches(text, pattern))
            {
                StringBuilder asterisks = new StringBuilder(match.Length);

                for (int i = 0; i < match.Length; i++)
                {
                    asterisks.Append((char)'*');
                }

                text = Regex.Replace(text, match.ToString(), asterisks.ToString());
            }
            Console.WriteLine(text);
        }
    }
}
