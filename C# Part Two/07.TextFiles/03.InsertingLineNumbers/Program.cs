using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.InsertingLineNumbers
{
    class Program
    {
        static void Write(StreamWriter output, string file)
        {
            
            using (StreamReader input = new StreamReader(file))
            {
                string line = input.ReadLine();
                int lineNumber = 1;
                while (line != null)
                {
                    output.WriteLine("{0} {1}", lineNumber, line);
                    line = input.ReadLine();
                    lineNumber++;
                }
            }
        }
        static void Main(string[] args)
        {
            string input = "asd.txt";

            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                Write(output, input);
            }
        }
    }
}
