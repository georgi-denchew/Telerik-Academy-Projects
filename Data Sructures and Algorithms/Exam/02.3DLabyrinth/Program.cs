using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._3DLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] startingLocationStr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int currentHeight = int.Parse(startingLocationStr[0]);
            int currentDepth = int.Parse(startingLocationStr[1]);
            int currentWidth = int.Parse(startingLocationStr[2]);

            string[] cubeSizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int height = int.Parse(cubeSizes[0]);
            int depth = int.Parse(cubeSizes[1]);
            int width = int.Parse(cubeSizes[2]);

            char[, ,] cube = new char[height, depth, width];


            bool[, ,] visited = new bool[height, depth, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < depth; j++)
                {
                    string currentRow = Console.ReadLine();

                    for (int k = 0; k < currentRow.Length; k++)
                    {
                        cube[i, j, k] = currentRow[k];

                        if (cube[i, j, k] == '#')
                        {
                            visited[i, j, k] = true;
                        }
                    }
                }
            }
            
            int currentSteps = 0;

            CalculateDistance(currentHeight, currentDepth, currentWidth, cube, currentSteps, visited);

            Console.WriteLine(minSteps);
        }

        static int minSteps = int.MaxValue;

        private static void CalculateDistance(int currentHeight, int currentDepth, int currentWidth, char[, ,] cube, int currentSteps, bool[, ,] visited)
        {
            if (currentHeight < 0 || currentHeight >= cube.GetLength(0))
            {
                minSteps = Math.Min(currentSteps, minSteps);
                return;
            }

            if (!InRange(currentHeight, currentDepth, currentWidth, cube) ||
                visited[currentHeight, currentDepth, currentWidth] || currentSteps > minSteps)
            {
                return;
            }

            visited[currentHeight, currentDepth, currentWidth] = true;

            if (cube[currentHeight, currentDepth, currentWidth] == 'D')
            {
                CalculateDistance(currentHeight - 1, currentDepth, currentWidth, cube, currentSteps + 1, visited);
            }
            else if (cube[currentHeight, currentDepth, currentWidth] == 'U')
            {
                CalculateDistance(currentHeight + 1, currentDepth, currentWidth, cube, currentSteps + 1, visited);
            }

            //if (InRange(currentHeight, currentDepth + 1, currentWidth, cube) &&
                //!visited[currentHeight, currentDepth + 1, currentWidth])
            //{
                CalculateDistance(currentHeight, currentDepth + 1, currentWidth, cube, currentSteps + 1, visited);
           // }

           // if (InRange(currentHeight, currentDepth - 1, currentWidth, cube) &&
               // !visited[currentHeight, currentDepth - 1, currentWidth])
          //  {
                CalculateDistance(currentHeight, currentDepth - 1, currentWidth, cube, currentSteps + 1, visited);
          //  }

          //  if (InRange(currentHeight, currentDepth, currentWidth + 1, cube) &&
             //   !visited[currentHeight, currentDepth, currentWidth + 1])
           // {
                CalculateDistance(currentHeight, currentDepth, currentWidth + 1, cube, currentSteps + 1, visited);
          //  }

           // if (InRange(currentHeight, currentDepth, currentWidth - 1, cube) &&
           //     !visited[currentHeight, currentDepth, currentWidth - 1])
           // {
                CalculateDistance(currentHeight, currentDepth, currentWidth - 1, cube, currentSteps + 1, visited);
           // }

            visited[currentHeight, currentDepth, currentWidth] = false;
        }

        private static bool InRange(int currentHeight, int currentDepth, int currentWidth, char[, ,] cube)
        {
            bool inRange = currentDepth >= 0 && currentDepth < cube.GetLength(1) && 
                currentWidth >= 0 && currentWidth < cube.GetLength(2);

            return inRange;
        }
    }
}
