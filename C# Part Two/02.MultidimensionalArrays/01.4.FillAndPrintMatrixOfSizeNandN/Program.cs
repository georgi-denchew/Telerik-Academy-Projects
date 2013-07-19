using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._4.FillAndPrintMatrixOfSizeNandN
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Convert.ToString(matrix[i, j]).PadLeft(3));
                }

                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows and cols here: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int number = 1;
            int first = 0;
            int last = n;

            while (last - first > 0)
            {
                for (int i = first; i < last; i++)
                {
                    matrix[i, first] = number++;
                }

                for (int i = first + 1; i < last; i++)
                {
                    matrix[last - 1, i] = number++;
                }

                for (int i = last - 2; i >= first; i--)
                {
                    matrix[i, last - 1] = number++;
                }

                for (int i = last - 2; i >= first + 1; i--)
                {
                    matrix[first, i] = number++;
                }

                first++;
                last--;
            }
            PrintMatrix(matrix);
        }
    }
}
