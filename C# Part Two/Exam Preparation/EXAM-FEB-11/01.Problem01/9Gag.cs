using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Problem01
{
    class Program
    {
        static List<decimal> numbers = new List<decimal>();
        static decimal result = 0;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            ListAdd(input);
            decimal multiplier = numbers.Count - 1;

            foreach (int number in numbers)
            {
                result += number * (decimal)Math.Pow(9, (double)multiplier);
                multiplier--;
            }
            Console.WriteLine(result);
        }

        private static void ListAdd(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' && i < input.Length - 1 && input[i + 1] == '!')
                {
                    numbers.Add(0);
                    i = i + 1;
                    continue;
                }
                if (input[i] == '*' && i < input.Length - 1 && input[i + 1] == '*')
                {
                    numbers.Add(1);
                    i = i + 1;
                    continue;
                }
                if (input[i] == '!' && i < input.Length - 2 && input[i + 1] == '!' && input[i + 2] == '!')
                {
                    numbers.Add(2);
                    i = i + 2;
                    continue;
                }
                if (input[i] == '&' && i < input.Length - 1 && input[i + 1] == '&')
                {
                    numbers.Add(3);
                    i = i + 1;
                    continue;
                }
                if (input[i] == '&' && i < input.Length - 1 && input[i + 1] == '-')
                {
                    numbers.Add(4);
                    i = i + 1;
                    continue;
                }
                if (input[i] == '!' && i < input.Length - 1 && input[i + 1] == '-')
                {
                    numbers.Add(5);
                    i = i + 1;
                    continue;
                }
                if (input[i] == '*' && i < input.Length - 3 && input[i + 1] == '!' && input[i + 2] == '!' && input[i + 3] == '!')
                {
                    numbers.Add(6);
                    i = i + 3;
                    continue;
                }
                if (input[i] == '&' && i < input.Length - 2 && input[i + 1] == '*' && input[i + 2] == '!')
                {
                    numbers.Add(7);
                    i = i + 2;
                    continue;
                }
                if (input[i] == '!' && i < input.Length - 5 && input[i + 1] == '!' && input[i + 2] == '*' && input[i + 3] == '*' && input[i + 4] == '!' &&
                    input[i + 5] == '-')
                {
                    numbers.Add(8);
                    i = i + 5;
                    continue;
                }
                //!!**!-!!**!-!!**!-
            }
        }
    }
}
