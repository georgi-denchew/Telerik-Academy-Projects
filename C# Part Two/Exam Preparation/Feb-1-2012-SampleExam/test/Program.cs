using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder code = new StringBuilder();
            int linesCount = int.Parse(Console.ReadLine());
            bool inMultilineComment = false;
            bool inString = false;
            bool inMultilineString = false;
            bool inSingleQuotedString = false;

            for (int i = 0; i < linesCount; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    if (inMultilineString)
                    {
                        if (line[j] == '\"' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            code.Append("\"\"");
                            j++;
                            continue;
                        }
                    }

                    if (inString)
                    {
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            code.Append("\\\"");
                            j++;
                            continue;
                        }


                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                        {
                            code.Append("\\\'");
                            j++;
                            continue;
                        }
                        if (line[j] == '\"' && !inSingleQuotedString)
                        {
                            inString = false;
                            inMultilineString = false;
                            code.Append('\"');
                            continue;
                        }
                        if (line[j] == '\'' && inSingleQuotedString)
                        {
                            inString = false;
                            inSingleQuotedString = false;
                            code.Append('\'');
                            continue;
                        }
                        code.Append(line[j]);
                        continue;
                    }

                    //multiline comments
                    if (!inMultilineComment && j + 1 < line.Length && line[j] == '/' && line[j + 1] == '*')
                    {
                        inMultilineComment = true;
                        j++;
                        continue;
                    }
                    if (inMultilineComment && j + 1 < line.Length && line[j] == '*' && line[j + 1] == '/')
                    {
                        inMultilineComment = false;
                        j++;
                        continue;
                    }
                    if (inMultilineComment)
                    {
                        continue;
                    }
                    //one line comment
                    if (line[j] == '/' && j + 1 < line.Length && line[j + 1] == '/')
                    {
                        if (j + 2 >= line.Length || line[j + 2] != '/')
                        {
                            break;
                        }
                        else
                        {
                            code.Append("///");
                            j += 2;
                            continue;
                        }
                    }
                    if (line[j] == '@' && j + 1 < line.Length && line[j + 1] == '\"')
                    {
                        inString = true;
                        inMultilineString = true;
                        j++;
                        code.Append("@\"");
                        continue;
                    }
                    if (line[j] == '\"')
                    {
                        inString = true;
                    }
                    if (line[j] == '\'')
                    {
                        inString = true;
                        inSingleQuotedString = true;
                    }
                    code.Append(line[j]);
                }
                if (!inMultilineComment) code.AppendLine();
            }
            StringReader sr = new StringReader(code.ToString());
            string lineToPrint = null;
            while ((lineToPrint = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(lineToPrint))
                {
                    Console.WriteLine(lineToPrint);
                }
            }
        }
    }
}
