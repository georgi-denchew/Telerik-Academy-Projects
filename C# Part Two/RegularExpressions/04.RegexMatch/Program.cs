using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.RegexMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"<html>
                           This is a hyperlink: 
                           <a href=""javascript:'window.close()'"">
                           close the window</a><br> ... and one more link: <a 
                           target=""_blank"" href=/main.aspx class='link'> <b>
                           main page</b> </a>< a href = 'http://www.nakov.com'
                           > <img src='logo.gif'>Nakov's home site < /a >";
            string hrefPattern = @"<\s*a\s[^>]*\bhref\s*=\s*" +
                @"('[^']*'|""[^""]*""|\S*)[^>]*>" +
                @"(.|\s)*?<\s*/a\s*>";
            Match match = Regex.Match(text, hrefPattern);
            while (match.Success)
            {
                Console.WriteLine("{0}\n\n", match);
                match = match.NextMatch();
            }
        }

    }
}
