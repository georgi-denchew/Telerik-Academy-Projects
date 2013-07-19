using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._3.FillAndPrintMatrixOfSizeNandN
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
            int[,] matrix = new int [n, n];
            int number = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[n - 1 - i + j, j] = number++;
                }
            }

            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    matrix[j, n - i + j] = number++;
                }
            }

            PrintMatrix(matrix);
        }
    }
}
