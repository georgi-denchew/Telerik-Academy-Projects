using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FirstElementBiggerThanNeighbours
{
    class Program
    {
        static int Index(int[] arr)
        {
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) //Checks only the elements with two neighbours
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter array length here: ");
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];

            Console.WriteLine("Enter array values here: ");

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("The index of the first element that is bigger than it's neighbours is: {0}", Index(arr));
        }
    }
}
