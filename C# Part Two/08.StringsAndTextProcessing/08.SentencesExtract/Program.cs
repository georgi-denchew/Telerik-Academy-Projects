using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string splitPattern = @"[.|!|?](\s*)";
        string[] sentences = Regex.Split(text, splitPattern);
        string pattern = @"\bin\b";

        foreach (string sentence in sentences)
        {
            Match match = Regex.Match(sentence, pattern);
            if (match.Success)
            {
                Console.WriteLine(sentence + ".");
            }
        }
    }
}
