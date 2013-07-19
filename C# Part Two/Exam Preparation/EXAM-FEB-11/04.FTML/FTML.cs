using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FTML
{
    class FTML
    {
        static bool toRev = false;
        static bool toUpper = false;
        static bool toLower = false;
        static bool toToggle = false;
        static bool toDel = false;
        static string append;
        static StringBuilder output = new StringBuilder();
        static StringBuilder rev = new StringBuilder();
        static int index = 0;
        static int i = 0;
        static string str;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder input = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                input.AppendLine(line);
            }
            str = input.ToString();
            for (i = 0; i < str.Length; i++)
            {

                if (str[i] == '<' && i < str.Length - 5 && str[i + 1] == '/' && str[i + 2] == 'd' && str[i + 3] == 'e' && str[i + 4] == 'l' && str[i + 5] == '>')
                {
                    toDel = false;
                    i = i + 5;
                    continue;
                }
                if (toDel)
                {
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 4 && str[i + 1] == 'd' && str[i + 2] == 'e' && str[i + 3] == 'l' && str[i + 4] == '>')
                {
                    toDel = true;
                    i = i + 4;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 4 && str[i + 1] == 'r' && str[i + 2] == 'e' && str[i + 3] == 'v' && str[i + 4] == '>')
                {
                    if (!toRev)
                    {
                        toRev = true;
                    }
                    else
                    {
                        toRev = false;
                    }
                    i = i + 4;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 5 && str[i + 1] == '/' && str[i + 2] == 'r' && str[i + 3] == 'e' && str[i + 4] == 'v' && str[i + 5] == '>')
                {
                    toRev = false;
                    char[] revChars = rev.ToString().ToCharArray();
                    StringBuilder appendChars = new StringBuilder();

                    for (int j = revChars.Length - 1; j >= 0; j--)
                    {
                        if (revChars[j] == '\r')
                        {
                            appendChars.Append("r\\");
                        }
                        else if (revChars[j] == '\n')
                        {
                            appendChars.Append("n\\");
                        }
                        else
                        {
                            appendChars.Append(revChars[j]);
                        }
                    }
                    output.Append(appendChars);
                    appendChars.Clear();
                    rev.Clear();
                    i = i + 5;
                    continue;
                }

                if (str[i] == '<' && i < str.Length - 6 && str[i + 1] == 'u' && str[i + 2] == 'p' && str[i + 3] == 'p' && str[i + 4] == 'e' && str[i + 5] == 'r' &&
                    str[i + 6] == '>')
                {
                    if (!toLower)
                    {
                        toUpper = true;
                    }
                    i = i + 6;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 7 && str[i + 1] == '/' && str[i + 2] == 'u' && str[i + 3] == 'p' && str[i + 4] == 'p' && str[i + 5] == 'e' &&
                    str[i + 6] == 'r' && str[i + 7] == '>')
                {
                    toUpper = false;
                    i = i + 7;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 6 && str[i + 1] == 'l' && str[i + 2] == 'o' && str[i + 3] == 'w' && str[i + 4] == 'e' && str[i + 5] == 'r' &&
                    str[i + 6] == '>')
                {
                    if (!toUpper)
                    {
                        toLower = true;
                    }
                    i = i + 6;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 7 && str[i + 1] == '/' && str[i + 2] == 'l' && str[i + 3] == 'o' && str[i + 4] == 'w' && str[i + 5] == 'e' &&
                    str[i + 6] == 'r' && str[i + 7] == '>')
                {
                    toLower = false;
                    i = i + 7;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 7 && str[i + 1] == 't' && str[i + 2] == 'o' && str[i + 3] == 'g' && str[i + 4] == 'g' && str[i + 5] == 'l' &&
                    str[i + 6] == 'e' && str[i + 7] == '>')
                {
                    toToggle = true;
                    i = i + 7;
                    continue;
                }
                if (str[i] == '<' && i < str.Length - 8 && str[i + 1] == '/' && str[i + 2] == 't' && str[i + 3] == 'o' && str[i + 4] == 'g' && str[i + 5] == 'g' && str[i + 6] == 'l' &&
                    str[i + 7] == 'e' && str[i + 8] == '>')
                {
                    toToggle = false;
                    i = i + 8;
                    continue;
                }

                if (str[i] == '\r' && i == str.Length - 2 && str[i + 1] == '\n')
                {
                    break;
                }
                if (str[i] == ' ' || str[i] == '\r' || str[i] == '\n')
                {
                    append = str[i].ToString();
                }
                else
                {
                    append = str[i].ToString().TrimStart();
                }
                AppendText(append);
            }
            string outputstr = output.ToString();
            Console.WriteLine(outputstr);
            
        }

        private static void AppendText(string p)
        {
            if (toUpper)
            {
                if (toToggle)
                {
                    if (toRev)
                    {
                        rev.Append(append.ToLower());
                        return;
                    }
                    output.Append(append.ToLower());
                    return;
                }
                if (toRev)
                {
                    rev.Append(append.ToUpper());
                    return;
                }
                output.Append(append.ToUpper());
                return;
            }
            if (toLower)
            {
                if (toToggle)
                {
                    if (toRev)
                    {
                        rev.Append(append.ToUpper());
                        return;
                    }
                    output.Append(append.ToUpper());
                    return;
                }
                if (toRev)
                {
                    rev.Append(append.ToLower());
                    return;
                }
                output.Append(append.ToLower());
                return;
            }

            if (toRev && !toToggle)
            {
                rev.Append(append);
                return;
            }

            if (toToggle)
            {
                if (char.IsUpper(str[i]))
                {
                    if (toRev)
                    {
                        rev.Append(append.ToLower());
                        return;
                    }
                    output.Append(append.ToLower());
                    return;
                }
                else
                {
                    if (toRev)
                    {
                        rev.Append(append.ToUpper());
                        return;
                    }
                    output.Append(append.ToUpper());
                    return;
                }
            }
            output.Append(append);
        }
    }
}