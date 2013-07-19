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
        string text = "<p>Please visit <a href=\"http://academy.telerik.com\">" +
            "our site</a> to choose a training course. Also visit " +
        "<a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        string pattern = @"<a href=\""(?<open>[a-z:/\.]+)"">(?<content>[a-z\s]+)</a>";
        string newPatt = "[URL=${open}]${content}[/URL]";
        MatchCollection matches = Regex.Matches(text, pattern);
        text = Regex.Replace(text, pattern, newPatt);
        Console.WriteLine(text);
    }
}
