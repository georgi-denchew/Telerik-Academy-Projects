using System;

namespace MatrixRefactoring
{
    class Initializer
    {
        static void Main(string[] args)
        {
            string inputStr;
            int size;

            do
            {
                Console.WriteLine("Enter number for matrix size between 1 and 100 inclusive");
                inputStr = Console.ReadLine();
            }
            while (!int.TryParse(inputStr, out size) || size < 1 || size > 100);

            Matrix matrix = new Matrix(size);

            matrix.FillMatrix();


            Console.WriteLine(matrix.ToString());
        }
    }
}
