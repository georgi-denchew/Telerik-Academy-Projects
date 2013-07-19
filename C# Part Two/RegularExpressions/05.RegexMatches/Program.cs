using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.RegexMatches
{
    class Program
    {
        static void Main()
        {
            // Регулярен израз за търсене на думи на кирилица
            Regex regex = new Regex(@"\b[А-Яа-я]+\b");

            String text =
                "The Bulgarian word 'бира' (beer) often" +
                " comes with the word 'скара' (grill).";

            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.Write("{0}: {1}, {2} ", match, match.Index, match.Length);
                Console.WriteLine();
            }

            // Резултат: бира скара
        }

    }
}
