using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder input = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine().TrimEnd();

                if (line != "" && line != null)
                {
                    input.AppendLine(line);
                }
            }

            string inputStr = input.ToString().Trim();
            StringBuilder output = new StringBuilder();
            bool isInMultilineComment = false;
            bool isInOneLineComment = false;
            bool isInQuotes = false;
            bool isInEscapeSequence = false;
            bool IsEmptyLine = false;

            for (int i = 0; i < inputStr.Length; i++)
            {
                if (inputStr[i] == '@' && inputStr[i + 1] == '\"')
                {
                    isInEscapeSequence = true;
                }
                else if (isInEscapeSequence && i < inputStr.Length - 1 && inputStr[i] == ';' && inputStr[i + 1] == '\r')
                {
                    isInEscapeSequence = false;
                }
                if (i < inputStr.Length - 1 && inputStr[i] == '/' && inputStr[i + 1] == '*' && !isInQuotes)
                {
                    isInMultilineComment = true;
                    i++;
                    continue;
                }
                else if (i < inputStr.Length - 1 && inputStr[i] == '/' && inputStr[i + 1] == '/' && !isInQuotes)
                {
                    isInOneLineComment = true;
                    if (i > 1 && inputStr[i - 1] == ' ' && inputStr[i - 2] == ' ')
                    {
                        IsEmptyLine = true;
                    }
                    continue;
                }

                else if (i < inputStr.Length - 1 && inputStr[i] == '*' && inputStr[i + 1] == '/' && !isInQuotes)
                {
                    isInMultilineComment = false;
                    //if ( i < inputStr.Length - 2 && inputStr[i + 2] == '\r' && inputStr[i + 3] == '\n')
                    //{
                    //    i += 2;
                    //}
                    i++;
                    continue;
                }
                else if (i < inputStr.Length - 1 && inputStr[i] == '\r' && inputStr[i + 1] == '\n' && isInOneLineComment)
                {
                    isInOneLineComment = false;
                    if (IsEmptyLine)
                    {
                        i = i + 2;
                        IsEmptyLine = false;
                    }
                }
                else if (inputStr[i] == '\"' && !isInQuotes)
                {
                    isInQuotes = true;
                }
                else if (isInQuotes && inputStr[i] == '\"' && inputStr[i - 1] != '\\')
                {
                    isInQuotes = false;
                }
                if (!isInMultilineComment && !isInOneLineComment)
                {
                    output.Append(inputStr[i]);
                }
            }
            string outputStr = output.ToString();
            Console.WriteLine(outputStr);
        }
    }
}
