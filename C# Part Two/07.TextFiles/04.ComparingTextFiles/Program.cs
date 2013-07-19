using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.ComparingTextFiles
{
    class Program
    {

        static void Main(string[] args)
        {
            using (StreamReader input1 = new StreamReader("asd.txt"))
            {
                using (StreamReader input2 = new StreamReader("dsa.txt"))
                {
                    string line1 = input1.ReadLine();
                    string line2 = input2.ReadLine();
                    int sameCount = 0;
                    int count = 0;
                    do
                    {
                        if (line1 == line2)
                        {
                            sameCount++;
                        }
                        count++;
                        line1 = input1.ReadLine();
                        line2 = input2.ReadLine();
                    } while (line1 != null && line2 != null);
                    Console.WriteLine("Number of lines, that are the same: {0}", sameCount);
                    Console.WriteLine("Number of lines, that are different: {0}", count - sameCount);

                }
            }

        }
    }
}
