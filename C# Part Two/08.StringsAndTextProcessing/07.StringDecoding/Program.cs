using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string Encode(string input, string cipher)
    {
        StringBuilder encrypted = new StringBuilder(input.Length);

        for (int i = 0; i < input.Length; i++)
        {
            encrypted.Append((char)(input[i] ^ cipher[i % cipher.Length]));
        }

        return encrypted.ToString();
    }

    static string Decode(string input, string cipher)
    {
        return Encode(input, cipher);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter string here: ");
        string input = Console.ReadLine();
        string cipher = "lock";

        Console.WriteLine("The encoded message is:");
        Console.WriteLine(Encode(input, cipher));

        Console.WriteLine("The decoded message is:");
        Console.WriteLine(Decode(Encode(input, cipher), cipher));
    }
}
