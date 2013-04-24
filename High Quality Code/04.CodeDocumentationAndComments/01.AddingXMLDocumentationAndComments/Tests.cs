using System;

namespace Telerik.ILS.Common
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "hello!";
            string yes = "да";
            string number = "123";
            string date = "31.12.2012";
            string username = "user_(*&";
            string filename = "file**&(";
            string file = "image.jgp";
            string extension = "jpg";

            //Tests
            Console.WriteLine(hello.ToMd5Hash());
            Console.WriteLine();
            Console.WriteLine(yes.ToBoolean());
            Console.WriteLine(number.ToShort());
            Console.WriteLine(number.ToInteger());
            Console.WriteLine(number.ToLong());
            Console.WriteLine();
            Console.WriteLine(date.ToDateTime());
            Console.WriteLine();
            Console.WriteLine(hello.CapitalizeFirstLetter());
            Console.WriteLine();
            Console.WriteLine(hello.GetStringBetween("h", "o", 0));
            Console.WriteLine();
            Console.WriteLine(yes.ConvertCyrillicToLatinLetters());
            Console.WriteLine();
            Console.WriteLine(hello.ConvertLatinToCyrillicKeyboard());
            Console.WriteLine();
            Console.WriteLine(username.ToValidUsername());
            Console.WriteLine();
            Console.WriteLine(filename.ToValidLatinFileName());
            Console.WriteLine();
            Console.WriteLine(hello.GetFirstCharacters(2));
            Console.WriteLine();
            Console.WriteLine(file.GetFileExtension());
            Console.WriteLine();
            Console.WriteLine(extension.ToContentType());
            Console.WriteLine();

            foreach (var item in number.ToByteArray())
            {
                Console.WriteLine(item);
            }
        }
    }
}
