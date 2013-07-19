using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

namespace _12.RemoveWords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string regex = @"\b(" + String.Join("|", File.ReadAllLines("words.txt")) + @")\b";
                using (StreamReader reader = new StreamReader("input.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("output.txt"))
                    {
                        for (string line; (line = reader.ReadLine()) != null; )
                        {
                            writer.WriteLine(Regex.Replace(line, regex, string.Empty));
                        }
                    }
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
