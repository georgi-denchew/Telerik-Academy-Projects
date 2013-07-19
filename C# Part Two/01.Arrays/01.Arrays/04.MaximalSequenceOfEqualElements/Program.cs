using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array here: ");
            int length = int.Parse(Console.ReadLine());
            int count = 1;
            int maxcount = 0;
            int maxcountNumbers = 1;
            int value = new int();
            int[] arr = new int[length];
            int[] sequenceNumber = new int[length];
            
            Console.WriteLine();
            Console.WriteLine("Enter values here:");
            for (int i = 0; i < length; i++)
            {

                arr[i] = int.Parse(Console.ReadLine());

                if (i > 0 && arr[i] == arr[i - 1])
                {
                    count++;

                    if (count > maxcount)
                    {
                        maxcount = count;
                        value = arr[i];
                        maxcountNumbers = 1;
                        Array.Clear(sequenceNumber, 0, length);
                    }

                    else if (count == maxcount)
                    {
                        maxcountNumbers++;
                        sequenceNumber[value] = value; // Siguren sum, 4e tova ne e nai-umniqt nachin, no samo za tova se setih.
                        sequenceNumber[i] = arr[i];
                    }
                }

                else 
                {
                    count = 1;
                }
            }

            if (maxcountNumbers == 1)
            {
                if (maxcount <= 1)
                {
                    Console.WriteLine("There is no sequence of equal elements");
                }

                else
                {
                    Console.WriteLine("The maximal sequence of equal elements in the array is:");

                    for (int i = 0; i < maxcount; i++)
                    {
                        Console.Write(value + " ");
                    }
                }

            }

            else
            {
                Console.WriteLine("The maximal sequences of equal elements in the array are:");
                foreach (int number in sequenceNumber)
                {
                    if (number != 0)
                    {
                        for (int i = 0; i < maxcount; i++)
                        {
                            Console.Write(number + " ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
