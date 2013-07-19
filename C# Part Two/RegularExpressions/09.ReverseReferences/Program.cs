using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.ReverseReferences
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "gosho gosho\n" + "pesho pesho\n" +
            "ivo kaka\n" + "kaka #k@k@22\n" + "test test";
            string pattern = @"^(?<user>\S+)\s+(\<user>)$";
            MatchCollection matches = Regex.Matches(text, pattern,
                RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                Console.Write("{0} ", match.Groups["user"]);
            }
            // Резултат: gosho pesho test

        }
    }
}
