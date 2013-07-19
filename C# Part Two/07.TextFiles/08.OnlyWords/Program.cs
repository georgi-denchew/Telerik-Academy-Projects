using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _08.OnlyWords
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
