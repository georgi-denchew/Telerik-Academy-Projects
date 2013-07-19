using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.RegexMatchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Регулярен израз за търсене на думи на латиница
            Regex regex = new Regex(@"\b[A-Za-z]+\b");

            String text =
                "Бирените историците смятат, че същинският " +
                "хмел (Humulus lupulus) влязъл трайно в " +
                "пивоварството едва през IX век.";

            Match match = regex.Match(text);
            while (match.Success)
            {
                Console.Write("{0}:{1} ", match, match.Index);
                match = match.NextMatch();
            }

        }
    }
}
