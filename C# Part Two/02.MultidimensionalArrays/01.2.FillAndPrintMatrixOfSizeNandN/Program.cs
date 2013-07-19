using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._2.FillAndPrintMatrixOfSizeNandN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter matrix rows and cols here: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col % 2 == 0)
                    {
                        matrix[row, col] = 1 + row + (col * n);
                        Console.Write(Convert.ToString(matrix[row, col]).PadLeft(2) + " ");
                    }

                    else
                    {
                        
                        matrix[row, col] = (n * (col + 1))- (row);
                        Console.Write(Convert.ToString(matrix[row, col]).PadLeft(2) + " ");
                    }
                }

                
                Console.WriteLine();
            }
        }
    }
}
