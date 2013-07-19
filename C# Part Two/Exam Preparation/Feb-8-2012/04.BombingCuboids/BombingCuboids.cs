using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BombingCuboids
{
    class BombingCuboids
    {
        static char[] separator = new char[] { ' ' };
        static int[] lettersHit = new int[91];
        static int totalHit = 0;
        const char Empty = ' ';
        static void Main(string[] args)
        {
            int width;
            int height;
            int depth;

            string[] dimensions = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
           
            width = int.Parse(dimensions[0]);
            height = int.Parse(dimensions[1]);
            depth = int.Parse(dimensions[2]);

            char[, ,] cube = InputCube( width, height, depth);

            int bombsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < bombsCount; i++)
            {
                string[] bombValues = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                int bombWidth = int.Parse(bombValues[0]);
                int bombHeight = int.Parse(bombValues[1]);
                int bombDepth = int.Parse(bombValues[2]);
                int power = int.Parse(bombValues[3]);

                DetonateBomb(cube, bombWidth, bombHeight, bombDepth, power);
                FallDown(cube);
            }
            PrintResult();
            PrintCube(width, height, depth, cube);
        }

        private static void PrintResult()
        {
            Console.WriteLine(totalHit);
            for (int i = 0; i < lettersHit.Length; i++)
            {
                if (lettersHit[i] != 0)
                {
                    Console.WriteLine("{0} {1}",(char)i, lettersHit[i]);
                }
            }
        }

        private static void FallDown(char[, ,] cube)
        {
            int width = cube.GetLength(0);
            int height = cube.GetLength(1);
            int depth = cube.GetLength(2);

            for (int pillarWidth = 0; pillarWidth < width; pillarWidth++)
            {
                for (int pillarDepth = 0; pillarDepth< depth; pillarDepth++)
                {
                    FallDownPillar(cube, pillarWidth, pillarDepth);
                }
            }
        }

        private static void FallDownPillar(char[, ,] cube, int pillarWidth, int pillarDepth)
        {
            int pillarHeight = cube.GetLength(1);

            int bottom = 0;

            for (int currHeight = 0; currHeight < pillarHeight; currHeight++)
            {
                if (cube[pillarWidth, currHeight, pillarDepth] != Empty)
                {
                    if (currHeight != bottom)
                    {
                        cube[pillarWidth, bottom, pillarDepth] = cube[pillarWidth, currHeight, pillarDepth];
                        cube[pillarWidth, currHeight, pillarDepth] = Empty;
                    }
                    bottom++;
                }
            }
        }

        private static void DetonateBomb(char[, ,] cube, int bombWidth, int bombHeight, int bombDepth, int power)
        {
            int width = cube.GetLength(0);
            int height = cube.GetLength(1);
            int depth = cube.GetLength(2);

            for (int currWidth = 0; currWidth < width; currWidth++)
            {
                for (int currHeight = 0; currHeight < height; currHeight++)
                {
                    for (int currDepth = 0; currDepth < depth; currDepth++)
                    {
                        if (!(cube[currWidth, currHeight, currDepth] == Empty))
                        {
                            int distSquarred = GetDistSquarred(currWidth, currHeight, currDepth, bombWidth, bombHeight, bombDepth);
                            int pSquarred = power * power;

                            if (distSquarred <= pSquarred)
                            {
                                char currLetter = cube[currWidth, currHeight, currDepth];
                                lettersHit[(int)currLetter]++;
                                totalHit++;
                                cube[currWidth, currHeight, currDepth] = Empty;
                            }
                        }
                    }
                }
            }
        }

        private static int GetDistSquarred(int currWidth, int currHeight, int currDepth, int bombWidth, int bombHeight, int bombDepth)
        {
            int deltaWidth = currWidth - bombWidth;
            int deltaHeight = currHeight - bombHeight;
            int deltaDepth = currDepth - bombDepth;
            return deltaWidth * deltaWidth + deltaHeight * deltaHeight + deltaDepth * deltaDepth; //M.pow 
        }

        private static void PrintCube(int width, int height, int depth, char[, ,] cube)
        {
            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        Console.Write(cube[currWidth, currHeight, currDepth]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static char[, ,] InputCube(int width, int height, int depth)
        {
            

            char[, , ] cube = new char[width, height, depth];

            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                string[] plateRows = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string currPlateRow = plateRows[currDepth];
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        cube[currWidth, currHeight, currDepth] = currPlateRow[currWidth];
                    }
                }
            }
            return cube;
        }
    }
}
