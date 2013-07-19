using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.BasicLanguage
{
    class Program
    {
        static StringBuilder basicLanguage = new StringBuilder();
        static int position = 0;
        static int a = 0;
        static int b = 0;
        static int i;
        static int multiplier = 0;
        static bool TwoVariables = false;
        static bool ToPrint = false;
        static void Main(string[] args)
        {
            while (!basicLanguage.ToString().Contains("EXIT;"))
            {
                string line = Console.ReadLine().Trim();
                basicLanguage.AppendLine(line);
            }

            //text = basicLanguage.ToString().Trim();

            for (i = 0; i < basicLanguage.Length; i++)
            {
                if (basicLanguage[i] == ' ' || basicLanguage[i] == '\r' || basicLanguage[i] == '\n')
                {
                    continue;
                }

                if ((basicLanguage[i] == 'F') && (basicLanguage[i + 1] == 'O') && (basicLanguage[i + 2] == 'R'))
                {
                    position = i + 3;
                    //For(basicLanguage, position);

                    StringBuilder aBuilder = new StringBuilder();
                    StringBuilder bBuilder = new StringBuilder();
                    for (int j = position; j < basicLanguage.Length; j++)
                    {
                        if (basicLanguage[j] == '(' || basicLanguage[j] == ' ' || basicLanguage[j] == '\r' || basicLanguage[j] == '\n')
                        {
                            continue;
                        }
                        if (((basicLanguage[j] >= '0' && basicLanguage[j] <= '9') || basicLanguage[j] == '-') && !TwoVariables)
                        {
                            aBuilder.Append((char)basicLanguage[j]);
                            continue;
                        }
                        if (basicLanguage[j] == ',')
                        {
                            TwoVariables = true;
                            continue;
                        }
                        if (((basicLanguage[j] >= '0' && basicLanguage[j] <= '9') || basicLanguage[j] == '-') && TwoVariables)
                        {
                            bBuilder.Append((char)basicLanguage[j]);
                            continue;
                        }
                        if (basicLanguage[j] == ')')
                        {
                            i = j;
                            break;
                        }
                    }
                    a = int.Parse(aBuilder.ToString());

                    if (TwoVariables)
                    {
                        b = int.Parse(bBuilder.ToString());
                        if (multiplier == 0) multiplier = 1;
                        multiplier = multiplier *(b - a + 1);
                    }
                    else
                    {
                        if (multiplier == 0) multiplier = a;
                        else multiplier *= a;
                        
                    }
                    aBuilder.Clear();
                    bBuilder.Clear();
                    TwoVariables = false;
                    continue;

                }

                if ((basicLanguage[i] == 'P') && (basicLanguage[i + 1] == 'R') && (basicLanguage[i + 2] == 'I') && (basicLanguage[i + 3] == 'N') && (basicLanguage[i + 4] == 'T'))
                {
                    position = i + 5;
                    //Print(basicLanguage, position);
                    StringBuilder print = new StringBuilder();
                    for (int j = position; j < basicLanguage.Length; j++)
                    {
                        if (basicLanguage[j] == '(' && !ToPrint)
                        {
                            ToPrint = true; continue;
                        }
                        if (basicLanguage[j] == ')')
                        {
                            ToPrint = false;
                            if (multiplier < 0) break;
                            if (multiplier == 0) multiplier = 1;
                            for (int k = 0; k < multiplier; k++)
                            {
                                Console.Write(print);
                            }
                            i = j;
                            multiplier = 0;
                            print.Clear();
                            break;
                        }
                        if (ToPrint) print.Append((char)basicLanguage[j]);
                    }
                    continue;
                }

                if ((basicLanguage[i] == 'E') && (basicLanguage[i + 1] == 'X') && (basicLanguage[i + 2] == 'I') && (basicLanguage[i + 3] == 'T'))
                {
                    Console.WriteLine();
                    Environment.Exit(0);
                }
            }
        }

        static void For(StringBuilder text, int position)
        {
        }

        static void Print(StringBuilder text, int position)
        {
            
        }
    }
}