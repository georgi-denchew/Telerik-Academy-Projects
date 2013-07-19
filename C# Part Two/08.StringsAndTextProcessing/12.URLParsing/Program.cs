using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.URLParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.devbg.org/forum/index.php";
            string patt = @"\A(?<protocol>\w+)[:/]+(?<server>[a-z\.]+)(?<resource>\b/.*)";
            Match match = Regex.Match(url, patt);
            Console.WriteLine(match.Success);
            GroupCollection gr = match.Groups;
            Console.WriteLine("[protocol] = \"{0}\"\n" + 
            "[server] = \"{1}\"\n" +
            "[resource] = \"{2}\"\n",gr["protocol"], gr["server"], gr["resource"]);
        }
    }
}
