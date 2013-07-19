using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05.MaxSum
{
    class Program
    {
        static int[,] Matrix()
        {

            using (StreamReader input = new StreamReader("maxsum.txt"))
            {
                int n = int.Parse(input.ReadLine());
                int[,] matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    string[] numbers = input.ReadLine().Split(' ');

                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = int.Parse(numbers[j]);
                    }
                }
                return matrix;
            }
        }

        static int Max(int[,] matrix)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    maxSum = Math.Max(maxSum, matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1]);
                }
            }
            return maxSum;
        }

        static void Result(int maxSum)
        {
            using(StreamWriter output = new StreamWriter ("output.txt"))
            {
                output.WriteLine(maxSum);
            }
        }
        static void Main(string[] args)
        {
            Result(Max(Matrix()));
        }
    }
}
