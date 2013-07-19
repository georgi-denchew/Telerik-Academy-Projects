using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MostFrequentNumberInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            int count = 1;
            int maxCount = 1;
            int position = 0;
            int[] frequentNumbers = new int[length];
            int numbersCount = 1;

            Console.WriteLine();
            Console.WriteLine("Enter numbers in the array here:");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);

            for (int i = 0; i < length; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        position = i;
                        maxCount = count;
                        Array.Clear(frequentNumbers, 0, length);
                        numbersCount = 1;
                    }

                    else if (count == maxCount)
                    {
                        numbersCount++;
                        frequentNumbers[i] = arr[i]; 
                    }
                }

                else
                {
                    count = 1;
                }
            }

            Console.WriteLine();

            if (maxCount == 1)
            {
                Console.WriteLine("There isn't any frequent number in the array");
            }

            else
            {
                if (numbersCount == 1)
                {
                    Console.WriteLine("The most frequent number is: {0} ({1} times)", arr[position], maxCount);
                }

                else
                {
                    Console.WriteLine("The most frequent numbers are:");
                    Console.WriteLine("{0} ({1} times)", arr[position], maxCount);

                    foreach (int number in frequentNumbers)
                    {
                        if (number != 0)
                        {
                            Console.WriteLine("{0} ({1} times)", number, maxCount);
                        }
                    }
                }
            }
        }
    }
}
