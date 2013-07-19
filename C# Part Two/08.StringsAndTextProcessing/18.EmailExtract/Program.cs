using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _18.EmailExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "unvalid@email-com @anotherunvalid and@one@more  zuzi_@kaval.bg;; ciki89@duduk.net, " +
             "bob@mail.bg\n\nfn12345@fmi.uni-sofia.bg\n" +
             "    mente@eu.int | , , ;;; gero@dir.bg";
            string pattern = @"\w+@\w+\.\w+";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }

        }
    }
}
