using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LargestAreaOfEqualNeighbours
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
        static bool IsTraversable(int[,] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
        }

        static int currentSum = 0;
        static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        static void DFS(int[,] matrix, int row, int col)
        {
            int value = matrix[row, col];
            matrix[row, col] = 0;
            currentSum++;
            for (int direction = 0; direction < directions.GetLength(0); direction++)
            {
                int _row = row + directions[direction, 0];
                int _col = col + directions[direction, 1];

                if (IsTraversable(matrix, _row, _col) && matrix[_row, _col] == value) DFS(matrix, _row, col);
            }
        }
        static void Main(string[] args)
        {
            int[,] matrix = { { 1, 3, 2, 2, 2, 4 }, { 3, 3, 3, 2, 4, 4 }, { 4, 3, 1, 2, 3, 3 }, { 4, 3, 1, 3, 3, 1 }, { 4, 3, 3, 3, 1, 1 } };

            int maxSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        currentSum = 0;
                        DFS(matrix, i, j);

                        maxSum = Math.Max(currentSum, maxSum);
                        PrintMatrix(matrix);
                        Console.WriteLine(currentSum + "\n");
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}