using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MaximalIncreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of the array here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            int count = 1;
            int maxcount = 0;
            int maxcountNumbers = 1;
            int lastNumber = 0;
            int[] sequences = new int[length];

            Console.WriteLine("Enter values for the array here:");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

                if (i > 0 && arr[i] == arr[i - 1] + 1)
                {
                    count++;

                    if (count > maxcount)
                    {
                        maxcount = count;
                        lastNumber = arr[i];
                        Array.Clear(sequences, 0, length);
                        maxcountNumbers = 1;
                    }

                    else if (count == maxcount)
                    {
                        maxcountNumbers++;
                        sequences[i] = arr[i];
                    }
                }

                else 
                {
                    count = 1;
                }
            }

            if (maxcountNumbers == 1)
            {
                if (maxcount <=1)
                {
                    Console.WriteLine("There is no sequence in the array.");
                }
                else
                {
                    Console.WriteLine("The maximal increasing sequence in the array is:");

                    for (int i = maxcount - 1; i >= 0; i--)
                    {
                        Console.Write((lastNumber - i) + " ");
                    }
                }

            }

            else 
            {
                Console.WriteLine("The maximal increasing sequences in the array are: ");

                for (int i = maxcount - 1; i >= 0; i--)
                {
                    Console.Write((lastNumber - i) + " ");
                }
                Console.WriteLine();

                foreach (int number in sequences)
                {
                    if (number != 0)
                    {
                        for (int i = maxcount - 1; i >= 0; i--)
                        {
                            Console.Write((number - i) + " ");
                        }
                    }
                }
            }
        }
    }
}
