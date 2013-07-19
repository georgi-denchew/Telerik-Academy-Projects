using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();

            PasswordsFinder finder = new PasswordsFinder(pattern);
            finder.CountPossiblePasswords();
        }
    }
}
