using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _17.FirstTwoWordsExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = " няма бира, дай ракия!";
            string pattern = @"\A\s*(\w+)(\W+)(\w+)";
            string newText = Regex.Replace(text, pattern, "3$2$1");
            Console.WriteLine(newText);
            // Резултат: бира няма, дай ракия!

        }
    }
}
