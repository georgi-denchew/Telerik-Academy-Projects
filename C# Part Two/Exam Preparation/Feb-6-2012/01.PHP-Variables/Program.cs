using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PHPVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            string phpCode = Read();
            List<string> variables = FindVariables(phpCode);
            Print(variables);
        }

        static string Read()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                string line = Console.ReadLine().Trim();
                input.AppendLine(line);
                if (line == "?>") break;
            }
            return input.ToString();
        }

        static bool IsVariableChar(char ch)
        {
            if (ch >= 'a' && ch <= 'z') return true;
            if (ch >= 'A' && ch <= 'Z') return true;
            if (ch >= '0' && ch <= '9') return true;
            if (ch == '_') return true;
            return false;
        }

        static List<string> FindVariables(string phpCode)
        {
            List<string> variables = new List<string>();

            bool IsInMultilineComment = false;
            bool IsInOneLineComment = false;
            bool IsInSingleQuotes = false;
            bool IsInDoubleQuotes = false;
            bool IsInVariableName = false;
            StringBuilder variableName = new StringBuilder();

            char ch;
            for (int i = 0; i < phpCode.Length; i++)
            {
                ch = phpCode[i];
                if (IsInMultilineComment)
                {
                    if (ch == '*' && phpCode[i + 1] == '/')
                    {
                        IsInMultilineComment = false;
                        i++;
                        continue;
                    }
                }

                if (IsInOneLineComment)
                {
                    if (ch == '\n')
                    {
                        IsInOneLineComment = false;
                        continue;
                    }
                }

                if (IsInVariableName)
                {
                    if (IsVariableChar(ch))
                    {
                        variableName.Append(ch);
                    }
                    else
                    {
                        string newVariable = variableName.ToString();
                        if (newVariable.Length > 0 && !variables.Contains(newVariable))
                        {
                            variables.Add(newVariable);
                        }

                        IsInVariableName = false;
                        variableName.Clear();
                    }
                }

                if (IsInSingleQuotes)
                {
                    if (ch == '\'')
                    {
                        IsInSingleQuotes = false;
                        continue;
                    }
                }

                if (IsInDoubleQuotes)
                {
                    if (ch == '\"')
                    {
                        IsInDoubleQuotes = false;
                        continue;
                    }
                }

                if (!IsInDoubleQuotes && !IsInSingleQuotes)
                {
                    if (ch == '#')
                    {
                        IsInOneLineComment = true;
                        continue;
                    }
                    if (ch == '/' && phpCode[i + 1] == '*')
                    {
                        IsInMultilineComment = true;
                        i++;
                        continue;
                    }
                    if (ch == '/' && phpCode[i + 1] == '/')
                    {
                        IsInOneLineComment = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if (ch == '\\')
                    {
                        i++;
                        continue;
                    }
                }
                if (ch == '\"')
                {
                    IsInDoubleQuotes = true;
                    continue;
                }
                if (ch == '\'')
                {
                    IsInOneLineComment = true;
                    continue;
                }
                if (ch == '$')
                {
                    IsInVariableName = true;
                    continue;
                }
            }
            return variables;
        }
        static void Print(List<string> variables)
        {
            Console.WriteLine(variables.Count);
            variables.Sort(StringComparer.Ordinal);
            foreach (string variable in variables)
            {
                Console.WriteLine(variable);
            }
        }
    }
}