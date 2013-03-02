using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ClassMatrixT
{
    //TASK 08: Define a class Matrix<T> to hold a matrix of numbers 
    //(e.g. integers, floats, decimals). 

    //TASK 09: Implement an indexer this[row, col] to access the
    //inner matrix cells.

    //TASK 10: Implement the operators + and - 
    //(addition and subtraction of matrices of the same size)
    //and * for matrix multiplication. Throw an exception when
    //the operation cannot be performed. Implement the true 
    //operator (check for non-zero elements).


    class Examples
    {
        static void Main(string[] args)
        {
            Matrix<int> arr = new Matrix<int>(2, 1);
            arr[0, 0] = 1;
            arr[1, 0] = 2;

            Matrix<int> arr2 = new Matrix<int>(2, 1);
            arr2[0, 0] = 1;
            arr2[1, 0] = 0;

            Matrix<int> sum = arr + arr2;
            Console.WriteLine(sum.ToString());
            Console.WriteLine();
            

            Matrix<int> substract = arr - arr2;
            Console.WriteLine(substract.ToString());
            Console.WriteLine();

            Matrix<int> multiply = arr * arr2;
            Console.WriteLine(multiply.ToString());
        }
    }
}
