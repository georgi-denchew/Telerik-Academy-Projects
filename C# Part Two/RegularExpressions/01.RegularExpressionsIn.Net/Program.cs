using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.RegularExpressionsIn.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            string text =
        "Няма скара, няма бира, няма к'во да ям.";
            // Регулярен израз за търсене на последователности
            // от букви и цифри, завършващи на "ира", подниз 
            // "скара" и думи, съдържащи в себе си подниз "ям"
            string pattern = @"\w*ира|скара|\w*ям\w*";
            Match match = Regex.Match(text, pattern);
            while (match.Success)
            {
                Console.WriteLine(
                    "Низ: \"{0}\" - начало {1}, дължина {2}",
                    match, match.Index, match.Length);
                match = match.NextMatch();

            }
        }
    }
}