using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _19.DateFormatCanada
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            string text = "02.02.2002 22.22.2222 12.12.2012 03.4.2011 04.05.2012 13.33.3333 222.22.1212";
            string pattern = @"[0-3]{1}[0-9]{1}.[0-1]{1}[0-9]{1}.[1-2]{1}[0-9]{3}";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                DateTime date = DateTime.ParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.CurrentCulture);
                Console.WriteLine(date);
            }
        }
    }
}
