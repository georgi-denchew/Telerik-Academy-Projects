using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.UppercaseChange
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            Regex regex = new Regex(@"<upcase>(?<caseChange>.*?)</upcase>");
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                text = regex.Replace(text, match.Groups["caseChange"].Value.ToUpper(), 1);
            }
            Console.WriteLine(text);
        }
    }
}