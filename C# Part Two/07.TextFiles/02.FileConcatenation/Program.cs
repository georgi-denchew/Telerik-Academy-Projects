using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.FileConcatenation
{
    class Program
    {
        static void Write(StreamWriter output, string file)
        {
            using (StreamReader input = new StreamReader(file))
            {
                string line = input.ReadLine();
                while (line != null)
                {
                    output.WriteLine(line);
                    line = input.ReadLine();
                }
                
            }
        }
        static void Main(string[] args)
        {
            string[] files = new string[2];
            files[0] = "123.txt";
            files[1] = "asd.txt";

            using (StreamWriter output = new StreamWriter("output.txt")) // in "..project\bin\debug\" 
            {
                foreach (string file in files)
                {
                    Write(output, file);
                }
            }
        }
    }
}
