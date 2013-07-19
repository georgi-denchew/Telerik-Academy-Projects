using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Clovers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] digits = new string[n];

            for (int i = 0; i < n; i++)
            {
                digits[i] = Console.ReadLine();
            }

            bool[] visited = new bool[n];

            char[] num = new char[n];
            CalculatePossibleNumbers(0, num, digits, visited);

            int minDivisors = int.MaxValue;
            int divisors = 0;
            int resultNumber = 0;

            SortedSet<int> minDivisorNumbers = new SortedSet<int>();

            foreach (int number in allNumbers)
            {
                divisors = 0;
                
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        divisors++;
                    }
                }

                if (divisors < minDivisors)
                {
                    minDivisorNumbers.Clear();
                    minDivisors = divisors;
                    resultNumber = number;
                    minDivisorNumbers.Add(number);
                }
                else if (divisors == minDivisors)
                {
                    minDivisorNumbers.Add(number);
                }
            }

            Console.WriteLine(minDivisorNumbers.Min);
        }
        
        static HashSet<int> allNumbers = new HashSet<int>();

        private static void CalculatePossibleNumbers(int currentIndex, char[] number, string[] digits, bool[] visited)
        {
            if (currentIndex >= digits.Length)
            {
                string strNumber = new string(number);
                allNumbers.Add(int.Parse(strNumber));
                return;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                if (!visited[i])
                {
                    number[currentIndex] = Convert.ToChar(digits[i]);
                    visited[i] = true;
                    CalculatePossibleNumbers(currentIndex + 1, number, digits, visited);
                    visited[i] = false;
                }
            }
        }
    }
}
