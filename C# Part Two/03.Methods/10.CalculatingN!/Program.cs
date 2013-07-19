using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CalculatingN_
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

            byte[] result = new byte[b2.Length + 1];

            int i = 0;
            int carry = 0;

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

        static byte[] Multiply(byte[] a, int b)
        {
            byte[] result = { 0 };

            for (int i = 0; i < b; i++)
            {
                result = Add(result, a);
            }

            return result;
        }
        static void Main(string[] args)
        {
            byte[] fact = { 1 };
            for (int i = 1; i <= 100; i++)
            {
                PrintNumber(fact = Multiply(fact, i));
            }
        }
    }
}
