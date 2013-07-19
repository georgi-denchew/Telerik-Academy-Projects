using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.CountSubstringInText
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "We are living in an yellow submarine. We don't have anything else."
            + "Inside the submarine is very tight. So we are drinking all the day."
            + "We will move out of it in 5 days.";
            string pattern = @"in";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);


            Console.WriteLine(matches.Count);
        }
    }
}
