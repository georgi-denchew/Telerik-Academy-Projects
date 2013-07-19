using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace _05.CharacterValueWithUnicodeSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.UTF8;
            char symbol = '\u0048';
            Console.WriteLine("Character Symbol:" + symbol);
        }
    }
}
