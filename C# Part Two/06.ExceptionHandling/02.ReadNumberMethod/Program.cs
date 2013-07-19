using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReadNumberMethod
{
    class Program
    {
        static void Print(int[] arr)
        {
            Console.WriteLine("The ten numbers are:");
            foreach (int element in arr)
            {
                Console.Write("{0} ", element);
            }
        }
        static int ReadNumber(int start, int end)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n < start || n > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return n;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Argument out of range! Enter a valid number!");

            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid number! Enter a valid number!");
            }
            return ReadNumber(start, end);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers \"start\" and \"end\":");
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int[] numbers = new int[10];

            Console.WriteLine("Enter ten numbers here:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("[{0}]:", i);
                int a = ReadNumber(start, end);
            
                if (i > 0)
                {
                    while (a <= numbers[i - 1])
                    {
                        Console.WriteLine("Enter a number, bigger than the previous!");
                        a = ReadNumber(start, end);
                    }

                    numbers[i] = a;
                }
            
                else
                {
                    numbers[i] = a;
                }
            }
            Print(numbers);
            Console.WriteLine();
        }
    }
}
