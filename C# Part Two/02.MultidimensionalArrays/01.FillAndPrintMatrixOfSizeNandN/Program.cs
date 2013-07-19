using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillAndPrintMatrixOfSizeNandN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" Enter the number of rows and cols of the matrix here: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 1 + row + (col * n);
                    Console.Write(Convert.ToString(matrix[row, col]).PadLeft(3));
                }

                Console.WriteLine();
            }
        }
    }
}