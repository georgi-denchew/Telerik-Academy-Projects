using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompareWithNeighbours
{
    class Program
    {
        static bool IsBigger(int[] arr, int position)
        {

            if (position > 0 && position < arr.GetLength(0) - 2)
            {
                if (arr[position] > arr[position - 1] && arr[position] > arr[position + 1])
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else if (position == 0)
            {
                if (arr[position] > arr[position + 1])
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else if (position == arr.GetLength(0) - 1)
            {
                if (arr[position] > arr[position - 1])
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter array length here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            Console.WriteLine("Enter array values here:");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter position here: ");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}", IsBigger(arr, position)? "The checked number is bigger than it's neighbours" : "The checked number isn't bigger than it's neighbours");
        }
    }
}
