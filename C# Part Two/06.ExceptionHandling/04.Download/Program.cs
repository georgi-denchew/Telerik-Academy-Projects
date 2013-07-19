using System;
using System.Net;
using System.Diagnostics;
using System.Threading;
namespace _04.Download
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter url:");
            string url = Console.ReadLine();
            Console.Write("Enter name for the file and .(extension): ");
            string name = Console.ReadLine() ;

            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.DownloadFile(url, name);
                    Console.WriteLine("You can find the file in: ..\\04.Download\\bin\\Debug");
                }

                catch (ArgumentNullException)
                {
                    Console.WriteLine("Not a valid web-address value. Please enter a valid address.");
                }

                catch (ArgumentException)
                {
                    Console.WriteLine("No web-address name. Please enter a valid address.");
                }

                catch (WebException)
                {
                    Console.WriteLine("Web address not found. Please enter a different address.");
                }

                catch(NotSupportedException)
                {
                    Console.WriteLine("this operation has already been completed");
                }
            }
        }
    }
}
