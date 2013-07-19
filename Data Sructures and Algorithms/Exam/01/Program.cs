using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigList<string[]> frames = new BigList<string[]>();

            for (int i = 0; i < n; i++)
            {
                frames.Add(Console.ReadLine().Split(' '));
            }

            bool[] visitedFrames = new bool[frames.Count];

            StringBuilder output = new StringBuilder();

            BigList<string[]> currentAnswer = new BigList<string[]>();

            //CountFrames(0, frames, visitedFrames, ref output);
        }

        static BigList<BigList<string[]>> answers = new BigList<BigList<string[]>>();

        private static void CountFrames(int frameIndex, BigList<string[]> frames, bool[] visitedFrames, BigList<string[]> currentAnswer)
        {
            if (frameIndex >= frames.Count)
            {
                return;
            }

            for (int i = 0; i < frames.Count; i++)
            {
                bool[] visitedNumbersInFrame = new bool[frames[i].Length];

                string[] resultFrame = new string[frames[i].Length];
                
                for (int j = 0; j < frames[i].Length; j++)
                {
                    if (!visitedNumbersInFrame[j])
                    {
                        visitedNumbersInFrame[j] = true;
                    }
                }
            }
        }
    }
}
