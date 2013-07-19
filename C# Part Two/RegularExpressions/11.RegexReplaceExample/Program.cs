using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.RegexReplaceExample
{
    class Program
    {static string CapitalizeFirstLetter(Match aMatch)
{
    string word = aMatch.Value;
    return Char.ToUpper(word[0]) + word.Substring(1);
}
static void Main()
{
    String text = "бирено парти - вход свободен!";
    string pattern = @"\w+";
    string newText = Regex.Replace(text, pattern, 
       CapitalizeFirstLetter);
    Console.WriteLine(newText); 
    // Резултат: Бирено Парти - Вход Свободен!
}

    }
}
