using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _16.EscapingRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Всички форми на думата 'бира' в даден" +
            @" текст можем да намерим с регулярния израз " +
            @"\b(Б|б)ир(((а|ичка)(та)?)|((и|ички)(те)?))\b.";
            string word = Console.ReadLine();
            String pattern = @"\b" + Regex.Escape(word) + @"\b";
            Match match = Regex.Match(text, pattern);

            while (match.Success)
            {
                Console.WriteLine(match);
                if (match == match.NextMatch())
                {
                    break;
                }
            } 
        }
    }
}
