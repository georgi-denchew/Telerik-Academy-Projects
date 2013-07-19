using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.RegexIsMatchExample
{
    class Program
    {
        static bool IsPositiveInteger(string aNumber)
        {
            // Целите положителни числа започват с цифра от 1 до 9 на
            // първа позиция и завършват с 0 или повече цифри в края
            Regex numberRegex = new Regex(@"\A[1-9][0-9]*\Z");
            return numberRegex.IsMatch(aNumber);
        }
        static void Check(string aText)
        {
            Console.WriteLine("{0} - {1}", aText,
                IsPositiveInteger(aText) ? "positive integer" :
                "NOT a positive integer");
        }
        static void Main(string[] args)
        {
            Check("123456";
            Check("15 16");
        }
    }
}