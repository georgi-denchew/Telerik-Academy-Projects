using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._3DLines
{
    class Program
    {
        static int width, height, depth;
        static char[, ,] cuboid;

        static int lineMaxLength = 0;
        static int linesCount;
        static bool[, , , , ,] processed;

        static void Main(string[] args)
        {
            ReadCuboid();
            FindLongestLine();

            if (lineMaxLength > 1)
            {
                Console.WriteLine("{0} {1}", lineMaxLength, linesCount);
            }
            else
            {
                Console.WriteLine(-1);
            }
            
        }

        private static void FindLongestLine()
        {
            processed = new bool[width, height, depth, 3, 3, 3];

            for (int startWidth = 0; startWidth < width; startWidth++)
            {
                for (int startHeight = 0; startHeight < height; startHeight++)
                {
                    for (int startDepth = 0; startDepth < depth; startDepth++)
                    {
                        ProcessLinesInAllDirection(startWidth, startHeight, startDepth);
                    }
                }
            }
        }

        private static void ProcessLinesInAllDirection(int startWidth, int startHeight, int startDepth)
        {
            for (int stepWidth = -1; stepWidth <= 1; stepWidth++)
            {
                for (int stepHeight = -1; stepHeight <= 1; stepHeight++)
                {
                    for (int stepDepth = -1; stepDepth <= 1; stepDepth++)
                    {
                        ProcessLine(startWidth, startHeight, startDepth, stepWidth, stepHeight, stepDepth);
                    }
                }
            }
        }

        private static void ProcessLine(int w, int h, int d, int stepWidth, int stepHeight, int stepDepth)
        {
            if (stepWidth == 0 && stepHeight == 0 && stepDepth == 0)
            {
                return;
            }
            if (IsProcessed(w, h, d, stepWidth, stepHeight, stepDepth))
            {
                return;
            }
            char color = cuboid[w, h, d];
            int length = 0;
            while (IsInsideTheCube(w + stepWidth, h + stepHeight, d + stepDepth) &&
                cuboid[w + stepWidth, h + stepHeight, d + stepDepth] == color)
            {
                w += stepWidth;
                h += stepHeight;
                d += stepDepth;
            }

            while (IsInsideTheCube(w, h, d) && cuboid[w, h, d] == color)
            {
                MarkAsProcessed(w, h, d, stepWidth, stepHeight, stepDepth);
                length++;
                if (length == lineMaxLength)
                {
                    linesCount++;
                }
                else if (length > lineMaxLength)
                {
                    lineMaxLength = length;
                    linesCount = 1;
                }

                w -= stepWidth;
                h -= stepHeight;
                d -= stepDepth;
            }
        }

        private static void MarkAsProcessed(int w, int h, int d, int stepWidth, int stepHeight, int stepDepth)
        {
            processed[w, h, d, stepWidth + 1, stepHeight + 1, stepDepth + 1] = true;
            processed[w, h, d, -stepWidth + 1, -stepHeight + 1, -stepDepth + 1] = true;
        }

        private static bool IsInsideTheCube(int w, int h, int d)
        {
            bool inside =
                w >= 0 && w < width &&
                h >= 0 && h < height &&
                d >= 0 && d < depth;
            return inside;
        }

        private static bool IsProcessed(int w, int h, int d, int stepWidth, int stepHeight, int stepDepth)
        {
            bool isProcessed =
                processed[w, h, d, stepWidth + 1, stepHeight + 1, stepDepth + 1] ||
                processed[w, h, d, -stepWidth + 1, -stepHeight + 1, -stepDepth + 1];
            return isProcessed;
        }

        

        private static void ReadCuboid()
        {
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            width = int.Parse(sizes[0]);
            height = int.Parse(sizes[1]);
            depth = int.Parse(sizes[2]);
            cuboid = new char[width, height, depth];

            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                string[] letters = Console.ReadLine().Split();

                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        cuboid[currWidth, currHeight, currDepth] = letters[currDepth][currWidth];
                    }
                }
            }
        }
    }
}
