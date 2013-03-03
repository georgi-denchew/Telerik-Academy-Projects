using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DivisibleBy7and3
{
    //TASK 06:Write a program that prints from given array of integers 
    //all numbers that are divisible by 7 and 3. Use the built-in
    //extension methods and lambda expressions. Rewrite the same with LINQ.

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 42, 63, 5, 6, 7, 14, 21 };

            int[] result =    // LINQ
                (from number in numbers
                 where (number % 3 == 0 && number % 7 == 0)
                 select number).ToArray();

            foreach (int number in result)
            {
                Console.WriteLine(number);
            }

            var lambdaResult = numbers.FindAll(number => number % 3 == 0 && number % 7 == 0); //LAMBDA

            foreach (var number in lambdaResult)
            {
                Console.WriteLine(number);
            }
        }
    }
}
