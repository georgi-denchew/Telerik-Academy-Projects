using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();
            char[] ch = str.ToCharArray();

            Array.Reverse(ch);

            string rev = new string(ch);
            Console.WriteLine(rev);
        }
    }
}
