using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _14.RegexOption
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "Бирата обирам. Налей ми биричка. Дайте още бира!";
            string pattern = @"бир";
            MatchCollection matches = Regex.Matches(
                text, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                Console.WriteLine("{0} {1} {2}", match, match.Index, match.Length);

            }
        }
    }
}