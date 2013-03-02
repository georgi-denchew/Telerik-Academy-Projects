using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ClassMatrixT
{
    public class Matrix<T> //TASK 08
        where T :  IComparable
    {
        
        private T[,] arr;
        public readonly int rows;
        public readonly int cols;

        public Matrix (int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.arr = new T[rows, cols];
        }     

        public T this[int row, int col] //TASK 09
        {
            get
            {
                if (row < 0 || col < 0 || row > this.rows - 1 || col > this.cols - 1)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid row or column!"));
                }
                T result = arr[row, col];

                return result;
            }
            set
            {

                arr[row, col] = value;
            }
            
        }

        public static Matrix<T> operator +(Matrix<T> t1, Matrix<T> t2) //TASK 10
        {
            
            Matrix<T> result = new Matrix<T>(t1.rows, t1.cols);
            if (t1.cols == t2.cols && t1.rows == t2.rows)
            {
                for (int i = 0; i < t1.rows; i++)
                {
                    
                    for (int j = 0; j < t1.cols; j++)
                    {
                        dynamic t1Dynamic = t1[i, j];
                        dynamic t2Dynamic = t2[i, j];
                        result[i, j] = t1Dynamic + t2Dynamic;
                    }
                }
                return result;
            }
            Console.WriteLine("The two matrixes have different size!");
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> t1, Matrix<T> t2) //TASK 10
        {

            Matrix<T> result = new Matrix<T>(t1.rows, t1.cols);
            if (t1.cols == t2.cols && t1.rows == t2.rows)
            {
                for (int i = 0; i < t1.rows; i++)
                {

                    for (int j = 0; j < t1.cols; j++)
                    {
                        dynamic t1Dynamic = t1[i, j];
                        dynamic t2Dynamic = t2[i, j];
                        result[i, j] = t1Dynamic - t2Dynamic;
                    }
                }
                return result;
            }
            Console.WriteLine("The two matrixes have different size!");
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> t1, Matrix<T> t2) //TASK 10
        {

            Matrix<T> result = new Matrix<T>(t1.rows, t1.cols);
            if (t1.cols == t2.cols && t1.rows == t2.rows)
            {
                for (int i = 0; i < t1.rows; i++)
                {

                    for (int j = 0; j < t1.cols; j++)
                    {
                        dynamic t1Dynamic = t1[i, j];
                        dynamic t2Dynamic = t2[i, j];
                        result[i, j] = t1Dynamic * t2Dynamic;
                    }
                }
                return result;
            }
            Console.WriteLine("The two matrixes have different size!");
            return result;
        }

        public string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    output.Append(this.arr[i, j].ToString() + " ");
                }
                output.Append("\r\n");
            }

            return output.ToString().Trim();
        }
    }
}