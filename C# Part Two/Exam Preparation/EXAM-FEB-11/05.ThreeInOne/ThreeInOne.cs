using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ThreeInOne
{
    class ThreeInOne
    {
        static int operations = 0;
        static void Main(string[] args)
        {
            int position;
            int winnersCount;
            FirstTaskBlackjack(out position, out winnersCount);
            int me = TaskTwoCakes();// TASK TWO - CAKES
            string[] money = Console.ReadLine().Split(' ');
            int g1 = int.Parse(money[0]);
            int s1 = int.Parse(money[1]);
            int b1 = int.Parse(money[2]);
            int g2 = int.Parse(money[3]);
            int s2 = int.Parse(money[4]);
            int b2 = int.Parse(money[5]);

            Solve(g1, s1, b1, g2, b2, s2);


            AnswerBlackjack(position, winnersCount);
            Console.WriteLine(me); //answerCakes
            Console.WriteLine(operations);
        }

        private static void Solve(int g1, int s1, int b1, int g2, int b2, int s2)
        {
            while (true)
            {
                if (g1 < g2)
                {
                    if (s1 > s2)
                    {
                        s1 = s1 - 11;
                        g1 = g1 + 1;
                        operations++;
                    }
                    else if (b1 > b2)
                    {
                        b1 = b1 - 11;
                        s1 = s1 + 1;
                        operations++;
                    }
                }
                if (s1 < s2)
                {
                    if (b1 > b2)
                    {
                        b1 = b1 - 11;
                        s1 = s1 + 1;
                        operations++;
                    }
                    else if (g1 > g2)
                    {
                        g1 = g1 - 1;
                        s1 = s1 + 9;
                        operations++;
                    }
                }
                if (b1 < b2)
                {
                    if (s1 > s2)
                    {
                        b1 = b1 + 9;
                        s1 = s1 - 1;
                        operations++;
                    }
                    else
                    {
                        g1 = g1 - 1;
                        s1 = s1 + 9;
                        operations++;
                    }
                }
                if (g1 >= g2 && s1 >= s2 && b1 >= b2)
                {
                    break;
                }
            }
        }

        private static int TaskTwoCakes()
        {
            string[] cakeSizesStr = Console.ReadLine().Split(',');
            int friends = int.Parse(Console.ReadLine());
            int me = 0;
            List<int> cakeSizes = new List<int>();

            for (int i = 0; i < cakeSizesStr.Length; i++)
            {
                cakeSizes.Add(int.Parse(cakeSizesStr[i]));
            }

            cakeSizes.Sort();

            for (int i = cakeSizes.Count - 1; i >= 0; i--)
            {
                me += cakeSizes[i];
                i = i - friends;
            }
            return me;
        }

        private static void AnswerBlackjack(int position, int winnersCount)
        {
            if (winnersCount == 1)
            {
                Console.WriteLine(position);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static void FirstTaskBlackjack(out int position, out int winnersCount)
        {
            string[] pointsString = Console.ReadLine().Split(',');
            List<int> pointsList = new List<int>();
            position = 0;
            int maxPoint = int.MinValue;
            winnersCount = 0;
            for (int i = 0; i < pointsString.Length; i++)
            {
                pointsList.Add(int.Parse(pointsString[i]));
            }

            for (int i = 0; i < pointsList.Count; i++)
            {
                if (pointsList[i] <= 21)
                {
                    if (pointsList[i] > maxPoint)
                    {
                        maxPoint = pointsList[i];
                        position = i;
                        winnersCount = 1;
                    }
                    else if (pointsList[i] == maxPoint)
                    {
                        winnersCount++;
                    }
                }
            }
        }
    }
}