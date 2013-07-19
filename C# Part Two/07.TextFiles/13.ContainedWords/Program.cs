using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

namespace _13.ContainedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] words = File.ReadAllLines("words.txt");
                int[] values = new int[words.Length];

                using (StreamReader reader = new StreamReader("test.txt"))
                {
                    for (string line; (line = reader.ReadLine()) != null; )
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            values[i] += Regex.Matches(line, @"\b" + words[i] + @"\b").Count;
                        }
                    }
                }

                Array.Sort(values, words);

                using (StreamWriter writer = new StreamWriter("result.txt"))
                {
                    for (int i = words.Length - 1; i >= 0; i--)
                    {
                        writer.WriteLine("{0}: {1}", words[i], values[i]);
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
