using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Result()
    {

        try
        {
            Console.Write("Enter string with maximum of 20 chars here: ");
            string str = Console.ReadLine();
            char[] arr = str.ToCharArray();

            if (arr.Length > 20)
            {
                throw new OverflowException();
            }

            char[] newArr = new char[20];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            for (int i = arr.Length; i < newArr.Length; i++)
            {
                newArr[i] = '*';
            }

            string result = new string(newArr);
            Console.WriteLine();
            Console.WriteLine(result);

        }
        catch (OverflowException)
        {
            Console.WriteLine();
            Console.WriteLine("The string you entered is more than 20 characters. Please try again.");
            Console.WriteLine();
            Result();
        }
    }
    static void Main(string[] args)
    {
        Result();
    }
}