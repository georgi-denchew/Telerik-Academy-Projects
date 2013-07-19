using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _09.DeletedOddLines
{
    class Program
    {
        static List<string> EvenLines()
        {
            List<string> newLines = new List<string>();

            using (StreamReader reader = new StreamReader("test1.txt"))
            {
                int count = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        newLines.Add(line);
                    }

                    line = reader.ReadLine();
                    count++;
                }
            }
            return newLines;
        }

        static void Write(List<string> newLines)
        {
            using (StreamWriter writer = new StreamWriter("test1.txt"))
            {
                foreach (string line in newLines)
                {
                    writer.WriteLine(line);
                }
            }
        }
        static void Main(string[] args)
        {
            Write(EvenLines());
        }
    }
}