using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06.SortingTextFile
{
    class Program
    {
        static List<string> Read()
        {
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader("input.txt")) //debug folder
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }
            lines.Sort();
            return lines;
        }

        static void Write(List<string> lines)
        {
            using (StreamWriter output = new StreamWriter("output.txt")) //debug folder
            {
                foreach (string line in lines)
                {
                    output.WriteLine(line);
                }
            }
        }
        static void Main(string[] args)
        {
            Write(Read());
        }
    }
}
