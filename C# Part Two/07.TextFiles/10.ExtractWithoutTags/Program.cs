using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10.ExtractWithoutTags
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader ("test.txt"))
            {
                for (int i; (i = reader.Read()) != -1; )
                {
                    if (i == '>')
                    {
                        string text = string.Empty;

                        while ((i = reader.Read()) != - 1 && i != '<')
                        {
                            text += (char)i;
                        }

                        if (!String.IsNullOrWhiteSpace(text))
                        {
                            Console.WriteLine(text.Trim());
                        }
                    }
                }
            }
        }
    }
}
