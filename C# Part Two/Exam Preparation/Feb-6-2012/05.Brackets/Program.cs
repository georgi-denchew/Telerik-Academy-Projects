using System;
using System.Numerics;

namespace _05.Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            int n = expression.Length;
            BigInteger[,] dp = new BigInteger[n + 1, n + 2];
            dp[0, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                if (expression[i - 1] == '(')
                {
                    dp[i, 0] = 0;

                }
                else
                {
                    dp[i, 0] = dp[i - 1, 1];
                }

                for (int j = 1; j <= n; j++)
                {
                    if (expression[i - 1] == '(')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (expression[i - 1] == ')')
                    {
                        dp[i, j] = dp[i - 1, j + 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j + 1];
                    }
                }
            }
            Console.WriteLine(dp[n, 0]);
        }
    }
}
