using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleRotationOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            string str = Convert.ToString(k);
            char firstStr = str[str.Length - 1];
            char secondstr = str[str.Length - 2];
            string modifiedStr = null;
            string checkstr = null;
            string count = null;
            char lastchar = '\0';

            if (k >= 1 && k <= 999999)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (str == null)
                    {
                        str = firstStr + str;
                        modifiedStr = null;
                        if (secondstr != null)
                        {
                            modifiedStr = secondstr + modifiedStr;
                        }
                        else
                        {
                            modifiedStr = firstStr + modifiedStr;
                        }
                    }
                    lastchar = str[str.Length - 1];
                    foreach (char ch in str)
                    {

                        count += ch;
                        if (count != str)
                        {
                            checkstr += ch;
                        }
                    }
                    count = null;
                    str = checkstr;
                    checkstr = null;
                    if (lastchar != '0')
                    {
                        modifiedStr = lastchar + modifiedStr;
                    }
                }
                modifiedStr = modifiedStr + str;
                Console.WriteLine(modifiedStr);
            }
        }
    }
}
