using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.StringToUnicodeChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();

            foreach (char ch in arr)
            {
                short s = (short)ch;
                Console.Write("\\u{0:X4}", (int)ch);
            }
            //StringBuilder unicode = new StringBuilder(input.Length);

            //foreach (char ch in input)
            //{
            //    unicode.AppendFormat("\\u{0:X4}", (int)ch);
            //}
            //Console.WriteLine(unicode);
            Console.WriteLine();
        }
    }
}
