using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BasicBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            string pleasantnessInput = Console.ReadLine();
            string[] inputArr = pleasantnessInput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] pleasantness = new int[inputArr.Length];
            int variety = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputArr.Length; i++)
            {
                pleasantness[i] = int.Parse(inputArr[i]);
            }

            Console.WriteLine(Problems(pleasantness, variety));
        }

        static int Problems(int[] pleasantness, int variety)
        {
            int count = 0;
            int maxPleas = int.MinValue;
            int maxPos = 0;
            int minPos = 0;
            int minPleas = int.MaxValue;
            for (int i = 0; i < pleasantness.Length; i++)
            {
                if (maxPleas < pleasantness[i])
                {
                    maxPleas = pleasantness[i];
                    maxPos = i;
                }
                if (minPleas > pleasantness[i])
                {
                    minPleas = pleasantness[i];
                    minPos = i;
                }

                if (maxPleas - minPleas >= variety)
                {
                    break;
                }
            }

            if (maxPleas - minPleas < variety)
            {
                return pleasantness.Length;
            }
            int lastPos = Math.Max(maxPos, minPos);

            for (int i = 0; i <= lastPos; i++)
            {
                if (i != lastPos && i + 1 != lastPos)
                {
                    count++;
                    i++;
                    continue;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }
    }
}