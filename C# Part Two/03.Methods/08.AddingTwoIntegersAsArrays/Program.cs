using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.AddingTwoIntegersAsArrays
{
    class Program
    {
        static void PrintNumber(byte[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }

        static byte[] Add(byte[] b1, byte[] b2)
        {
            if (b1.Length > b2.Length)
            {
                return Add(b2, b1);
            }

            PrintNumber(b1);
            PrintNumber(b2);

            byte[] result = new byte[b2.Length + 1];

            int carry = 0;
            int i = 0;

            for (; i < b1.Length; i++)
            {
                result[i] = (byte)(b1[i] + b2[i] + carry);

                carry = result[i] / 10;
                result[i] %= 10;
            }

            for (; i < b2.Length && carry != 0; i++)
            {
                result[i] = (byte)(b2[i] + carry);
                carry = result[i] / 10;
                result[i] %= 10;
            }

            for (; i < b2.Length; i++)
            {
                result[i] = b2[i];
            }

            if (carry != 0)
            {
                result[i] = 1;
            }

            else
            {
                Array.Resize(ref result, result.Length - 1);
            }

            return result;
        }
        static void Main(string[] args)
        {
            PrintNumber(Add(new byte[] { 1 }, new byte[] { 0 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 2 }, new byte[] { 3 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 1, 0 }, new byte[] { 1 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 1, 2 }, new byte[] { 9 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 1, 1 }, new byte[] { 9, 9 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9, 9 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9, 9, 8 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 1 }, new byte[] { 9, 9, 9, 9, 9 , 9 }));
            Console.WriteLine();

            PrintNumber(Add(new byte[] { 2 }, new byte[] { 8, 9, 9, 9, 9, 9 }));
        }
    }
}
