using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _15.RegexOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "Бирата намаля.\nДайте още бира!";
            string pattern = @"^\w+";  //търсим думи в началото на ред
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                Console.Write("{0} ", match);
            }
// Заради опцията Multiline резултатът е: Бирата Дайте

        }
    }
}
