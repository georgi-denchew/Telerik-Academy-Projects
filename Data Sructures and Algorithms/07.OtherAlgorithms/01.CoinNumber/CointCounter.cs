namespace _01.CoinNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class CointCounter
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sum for the coins: ");
            int sum = int.Parse(Console.ReadLine());

            int[] coins = new int[3] { 5, 2, 1 };

            Dictionary<int, int> coinsCount = new Dictionary<int, int>();

            CountCoinsNeeded(coins, sum, coinsCount);

            StringBuilder output = new StringBuilder();

            foreach (var coin in coinsCount)
            {
                output.Append(string.Format("{0} coins x {1} + ", coin.Value, coin.Key));
            }

            output.Length -= 3;
            Console.WriteLine(output.ToString());
        }

        private static void CountCoinsNeeded(int[] coins, int sum, Dictionary<int, int> coinsCount)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                coinsCount.Add(coins[i], 0);
            }

            int currentCoinIndex = 0;
            int currentSum = 0;

            while (true)
            {
                if (currentSum == sum)
                {
                    break;
                }

                if (currentSum + coins[currentCoinIndex] <= sum)
                {
                    currentSum += coins[currentCoinIndex];

                    coinsCount[coins[currentCoinIndex]]++;
                }
                else
                {
                    currentCoinIndex++;
                }
            }
        }
    }
}
