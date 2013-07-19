using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01.Frames
{
    class Program
    {
        static SortedSet<BigList<string[]>> solutions = new SortedSet<BigList<string[]>>();

        static void Main(string[] args)
        {
            int framesCount = int.Parse(Console.ReadLine());


            BigList<string[]> frames = new BigList<string[]>();
            bool[] visitedFrames = new bool[frames.Count];

            for (int i = 0; i < framesCount; i++)
            {
                string[] frame = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                frames.Add(frame);
            }

            int currentFrame = 0;
            int currentFrameIndex = 0;

            bool[] visitedFrameIndices = new bool[frames[0].Length];
            string[] tempFrame = new string[frames[0].Length];

            CalculateFrames(currentFrame, currentFrameIndex, frames, visitedFrames, visitedFrameIndices, tempFrame);

        }

        private static void CalculateFrames(int currentFrame, int currentFrameIndex, BigList<string[]> frames, bool[] visitedFrames,
            bool[] visitedFrameIndices, string[] tempFrame)
        {
            BigList<string[]> tempFrames = new BigList<string[]>();

            for (int i = 0; i < frames.Count; i++)
            {                

                if (currentFrameIndex >= frames[i].Length)
                {
                }

                for (int j = 0; j < frames[i].Length; j++)
                {
                    if (!visitedFrameIndices[j])
                    {
                        tempFrame[currentFrameIndex] = frames[i][j];
                        visitedFrameIndices[j] = true;
                        //CalculateFrames(currentFrame, currentFrameIndex + 1, frames);
                    }
                }
            }
        }


    }
}
