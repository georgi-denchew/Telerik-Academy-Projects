using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _18.DateParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "17.03.2004 12:11:05";

            string pattern =
             @"\A(?<day>\d+)          
             (\.|\/)                  
             (?<month>\d+)            
             (\.|\/)                  
             (?<year>(19|20)?\d{2})   
             \s+                      
             (?<hour>\d+)             
             :                        
             (?<min>\d+)              
             (:(?<sec>\d+))?";

            Match match = Regex.Match(text, pattern,
                RegexOptions.IgnorePatternWhitespace);

            if (match.Success)
{
    GroupCollection gr = match.Groups;
    Console.WriteLine("day={0} month={1} year={2}\n" +
        "hour={3} min={4} sec={5}", 
        gr["day"], gr["month"], gr["year"],
        gr["hour"], gr["min"], gr["sec"]);
}
else  
{
    Console.WriteLine("Invalid date and time!");
}

        }
    }
}
