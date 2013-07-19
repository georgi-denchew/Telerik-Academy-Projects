using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace _03.FileRead
{
    class Program
    {
        static void Read(string path)
        {
            string content = File.ReadAllText(path);
            Console.WriteLine("Content:");
            Console.WriteLine(content);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Enter path of the file: ");
            string path = Console.ReadLine();

            try
            {
                Read(path);
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Please enter path different than null");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The path you entered is either a zero-length string, contains only white spaces, or contains one or more invalid characters. Please enter a valid path.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path, file name, or both exceed the maximum length. Please enter a different path.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Please enter a valid directory.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Path was not found");
            }
            catch (IOException)
            {
                Console.WriteLine("Cannot open the file. Please try again.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have access to this file. ");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("That is not a valid path format");
            }
            catch (SecurityException)
            {
                Console.WriteLine("You don't have permition to access this file.");
            }
        }
    }
}
