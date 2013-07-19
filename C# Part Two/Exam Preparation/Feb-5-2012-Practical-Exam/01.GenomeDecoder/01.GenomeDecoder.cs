using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenomeDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nAndM = Console.ReadLine().Split(new char[] { ' ' });
            int n = int.Parse(nAndM[0]);
            int m = int.Parse(nAndM[1]);

            string input = Console.ReadLine();
            StringBuilder multiplier = new StringBuilder();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    multiplier.Append(input[i]);
                }

                else
                {
                    int multiply;
                    if (multiplier.ToString() != "")
                    {
                        multiply = int.Parse(multiplier.ToString());
                    }
                    else
                    {
                        multiply = 1;
                    }
                    for (int j = 0; j < multiply; j++)
                    {
                        output.Append(input[i]);
                    }
                    multiplier.Clear();
                }
            }
            int lineCount = 1;
            int letterCount = 0;
            int outputCount = 0;
            string outputStr = output.ToString();
            int lastline;
            if (outputStr.Length % n != 0)
            {
                lastline = outputStr.Length / n + 1;
            }
            else
            {
                lastline = outputStr.Length / n;
            }

            for (lineCount = 1; lineCount <= lastline; lineCount++)
            {
                for (int i = 0; i < lastline.ToString().Length - lineCount.ToString().Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("{0} ", lineCount);

                for (int i = 0; i < n; i++)
                {
                    if (letterCount == m)
                    {
                        Console.Write(" ");
                        letterCount = 0;
                    }
                    if (outputCount < outputStr.Length)
                    {
                        Console.Write("{0}", outputStr[outputCount]);
                    }
                    outputCount++;
                    letterCount++;
                }
                letterCount = 0;
                Console.WriteLine();

            }
        }
    }
}
