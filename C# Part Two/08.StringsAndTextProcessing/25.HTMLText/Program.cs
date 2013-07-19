using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _25.HTMLText
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "<html><head><title>News</title></head>" +
              "<body><p><a href=\"http://academy.telerik.com\">Telerik" +
                "Academy</a>aims to provide free real-world practical" +
                "training for young people who want to turn into" +
                "skillful .NET software engineers.</p></body></html>";
            string pattern = @">(?<notags>[\w\s\.-]+)<";
            MatchCollection matches = Regex.Matches(text, pattern);
            
            foreach (Match match in matches)
            {
                 StringBuilder result = new StringBuilder();
                for (int i = 0; i < match.Length; i++)
                {
                    if (match.ToString()[i] != '>' && match.ToString()[i] != '<')
                    {
                        result.Append((char)(match.ToString()[i]));
                    }
                }
                Console.WriteLine(result);
            }

        }
    }
}