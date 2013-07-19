using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LongestSequenceInAMatrix
{
    class Program
    {
        static void PrintMatrix(string[,] matrix)
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
            string[,] matrix = new string[n, m];
            string rowString = null;
            string colString = null;
            string diagString = null;
            string opositeDiag = null;
            int rowCheck = 1;
            int rowMax = 0;
            int colCheck = 1;
            int colMax = 0;
            int diagCheck = 1;
            int diagMax = 0;
            int opositeCheck = 1;
            int opositeMax = 0;


            Console.WriteLine("Enter values for the matrix here:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("[{0}, {1}]: ", i, j);
                    matrix[i, j] = Console.ReadLine();
                }
            }

            Console.WriteLine();
            PrintMatrix(matrix);
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i > 0 && matrix[n - i - 1 + j, j] == matrix[n - i + j, j + 1])
                    {
                        diagCheck++;

                        if (diagCheck > diagMax)
                        {
                            diagMax = diagCheck;
                            diagString = matrix[n - i - 1 + j, j];
                        }
                    }
                   
                    else
                    {
                        diagCheck = 1;
                    }
                }

                diagCheck = 1;
            }

            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (matrix[j, n - i + j] == matrix[j + 1, n - i + j + 1])
                    {
                        diagCheck++;

                        if (diagCheck > diagMax)
                        {
                            diagMax = diagCheck;
                            diagString = matrix[n - i - 1 + j, j];
                        }
                    }

                    else
                    {
                        diagCheck = 1;
                    }
                }

                diagCheck = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (matrix[j, i - j] == matrix[j + 1, i - 1 - j])
                    {
                        opositeCheck++;

                        if (opositeCheck > opositeMax)
                        {
                            opositeMax = opositeCheck;
                            opositeDiag = matrix[j, j + 1];
                        }
                    }

                    else
                    {
                        opositeCheck = 1;
                    }
                }

                opositeCheck = 1;
            }

            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (matrix[n - i - 1 + j, i + 1 - j] == matrix[n - i + j,  i - j])
                    {
                        opositeCheck++;

                        if (opositeCheck > opositeMax)
                        {
                            opositeMax = opositeCheck;
                            opositeDiag = matrix[j, i + 1 - j];
                        }
                    }

                    else
                    {
                        opositeCheck = 1;
                    }
                }
                opositeCheck = 1;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        rowCheck++;

                        if (rowCheck > rowMax)
                        {
                            rowMax = rowCheck;
                            rowString = matrix[i, j];
                        }
                    }

                    else
                    {
                        rowCheck = 1;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (matrix[j, i] == matrix[j + 1, i])
                    {
                        colCheck++;

                        if (colCheck > colMax)
                        {
                            colMax = colCheck;
                            colString = matrix[j, i];
                        }
                    }
                    else
                    {
                        colCheck = 1;
                    }
                }

                colCheck = 1;
            }

            Console.WriteLine("The longest sequence is/are:");

            if (rowMax >= colMax && rowMax >= diagMax && rowMax >= opositeMax )
            {
                for (int i = 0; i < rowMax; i++)
                {
                    Console.Write(rowString + " ");
                }
                Console.WriteLine();
            }

            if (colMax >= rowMax && colMax >= diagMax && colMax >= opositeMax)
            {
                for (int i = 0; i < colMax; i++)
                {
                    Console.Write(colString + " ");
                }
                Console.WriteLine();
            }

            if (diagMax >= rowMax && diagMax >= colMax && diagMax >= opositeMax)
            {
                for (int i = 0; i < diagMax; i++)
                {
                    Console.Write(diagString + " ");
                }
            }

            if (opositeMax >= rowMax && opositeMax >= colMax && opositeMax >= diagMax)
            {
                for (int i = 0; i < opositeMax; i++)
                {
                    Console.Write(opositeDiag + " ");
                }
            }
        }
    }
}