using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.WorkingWithGroups_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "gosho 62.44.18.124 02:44:50\n" +
    "root 193.168.22.18 22:12:38\n" +
    "nakov 217.9.231.126 00:07:24";
            string pattern =
                @"(?<name>\S+)\s+(?<ip>[0-9\.]+)\s+(?<time>[0-9:]+)";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                
                Console.WriteLine("name={0,-8} ip={1,-16} time={2}",
                    match.Groups["name"], match.Groups["ip"],
                    match.Groups["time"]);
            }

        }
    }
}
