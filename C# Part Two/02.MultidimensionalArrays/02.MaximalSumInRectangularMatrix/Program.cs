using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaximalSumInRectangularMatrix
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
            Console.Write("Enter N rows here: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M columns here: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            int rowStart = 0;
            int colStart = 0;
            int sum = 0;
            int maxSum = 0;

            Console.WriteLine("Enter values for the matrix here:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    sum = matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j] + matrix[i, j + 1] + matrix[i + 1, j + 1] + matrix[i + 2, j + 1] +
                    matrix[i, j + 2] + matrix[i + 1, j + 2] + matrix[i + 2, j + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowStart = i;
                        colStart = j;
                    }

                    else 
                    {
                        sum = 0;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Your matrix is:");
            PrintMatrix(matrix);
            Console.WriteLine();
            Console.WriteLine("The maximal sum is: {0}", maxSum);
            Console.WriteLine("The 3x3 square with maximal sum is: ");
            Console.WriteLine();
            Console.WriteLine(matrix[rowStart, colStart] + " " + matrix[rowStart, colStart + 1] + " " + matrix[rowStart, colStart + 2]);
            Console.WriteLine(matrix[rowStart + 1, colStart] + " " + matrix[rowStart + 1, colStart + 1] + " " + matrix[rowStart + 1, colStart + 2]);
            Console.WriteLine(matrix[rowStart + 2, colStart] + " " + matrix[rowStart + 2, colStart + 1] + " " + matrix[rowStart + 2, colStart + 2]);
        }
    }
}
