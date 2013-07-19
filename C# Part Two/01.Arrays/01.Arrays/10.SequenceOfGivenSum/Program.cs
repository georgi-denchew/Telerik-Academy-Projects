using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SequenceOfGivenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            Console.Write("Enter sum here: ");
            int sum = int.Parse(Console.ReadLine());
            int checkSum = 0;
            int position = 0;
            int count = 0;
            int numbersCount = 0;
            int[] sequence = new int[length];

            Console.WriteLine("Enter numbers in the array here:");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("The sequence(s) of the given sum is/are:");
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    count++;
                    checkSum += arr[j];
                    sequence[j] = arr[j];
                    if (checkSum == sum)
                    {
                        position = j;
                        numbersCount = count;

                        foreach (int number in sequence)
                        {
                            if (number != 0)
                            {
                                Console.Write(number + " ");
                            }
                        }

                        Console.WriteLine();
                        
                        count = 0;
                        checkSum = 0;
                        Array.Clear(sequence, 0, length);
                        break;
                    }

                    else if (checkSum > sum)
                    {
                        Array.Clear(sequence, 0, length);
                        count = 0;
                        checkSum = 0;
                        break;
                    }
                }
            }


        }
    }
}
