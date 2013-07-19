using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._3DMaxWalk
{
    class Program
    {
        static int width;
        static int height;
        static int depth;
        static short[, ,] cuboid;
        static bool[, ,] visited;

        static void Main(string[] args)
        {
            ReadCuboid();
            long sum = CalculateWalkSum();
            Console.WriteLine(sum);
        }

        private static void ReadCuboid()
        {
            string[] whd = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            width = int.Parse(whd[0]);
            height = int.Parse(whd[1]);
            depth = int.Parse(whd[2]);
            cuboid = new short[width, height, depth];
            long sum = CalculateWalkSum();

            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                string[] sequences = Console.ReadLine().Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string[] numbers = sequences[currDepth].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        short cubeValue = short.Parse(numbers[currWidth]);
                        cuboid[currWidth, currHeight, currDepth] = cubeValue;
                    }
                }
            }
        }

        private static long CalculateWalkSum()
        {
            int w = width / 2;
            int h = height / 2;
            int d = depth / 2;
            bool finished = false;
            long sum = cuboid[w, h, d];
            visited = new bool[width, height, depth];

            while (!finished)
            {
                visited[w, h, d] = true;
                int newW, newH, newD, maxCount;
                GetNextPosition(w, h, d, out newW, out newH, out newD, out maxCount);

                if (visited[newW, newH, newD] || maxCount > 1)
                {
                    finished = true;
                }
                else
                {
                    sum += cuboid[newW, newH, newD];
                    w = newW;
                    h = newH;
                    d = newD;
                }
            }
            return sum;
        }

        private static void GetNextPosition(int w, int h, int d, out int newW, out int newH, out int newD, out int maxCount)
        {
            short maxValue = short.MinValue;
            newW = 0;
            newH = 0;
            newD = 0;
            maxCount = 0;

            short oldCurrentPositionValue = cuboid[w, h, d];
            cuboid[w, h, d] = short.MinValue;

            //check left and right
            for (int nextW = 0; nextW < width; nextW++)
            {
                short value = cuboid[nextW, h, d];
                if (value == maxValue)
                {
                    maxCount++;
                }

                if (value > maxValue)
                {
                    maxValue = value;
                    newW = nextW;
                    newH = h;
                    newD = d;
                    maxCount = 1;
                }
            }
            //check up and down
            for (int nextH = 0; nextH < height; nextH++)
            {
                short value = cuboid[w, newH, d];
                if (value == maxValue)
                {
                    maxCount++;
                }
                if (value > maxValue)
                {
                    maxValue = value;
                    newW = w;
                    newH = nextH;
                    newD = d;
                    maxCount = 1;
                }
            }

            //deep and shallow
            for (int nextD = 0; nextD < depth; nextD++)
            {
                short value = cuboid[w, h, newD];
                if (value == maxValue)
                {
                    maxCount++;
                }
                if (value > maxValue)
                {
                    maxValue = value;
                    newW = w;
                    newH = h;
                    newD = nextD;
                    maxCount = 1;
                }
            }
            cuboid[w, h, d] = oldCurrentPositionValue;
        }
    }
}
