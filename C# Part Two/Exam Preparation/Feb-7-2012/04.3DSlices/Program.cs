using System;
using System.Collections.Generic;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        string cuboidSize = Console.ReadLine();
        string[] sizes = cuboidSize.Split();
        int width = int.Parse(sizes[0]);
        int height = int.Parse(sizes[1]);
        int depth = int.Parse(sizes[2]);

        short[, ,] cuboid = new short[width, height, depth];

        long Sum = 0;

        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] sequences = line.Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] numbers = sequences[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    short cubeValue = short.Parse(numbers[w]);
                    cuboid[w, h, d] = cubeValue;
                    Sum = Sum + cubeValue;
                }
            }
        }

        int splitsCount = 0;

        long currentSum = 0;
        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum = currentSum + cuboid[w, h, d];
                }
            }
            if (currentSum * 2 == Sum)
            {
                splitsCount++;
            }
        }
        currentSum = 0;
        for (int h = 0; h < height - 1; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum = currentSum + cuboid[w, h, d];
                }
            }
            if (currentSum * 2 == Sum)
            {
                splitsCount++;
            }
        }

        currentSum = 0;
        for (int d = 0; d < depth - 1; d++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    currentSum = currentSum + cuboid[w, h, d];
                }
            }
            if (currentSum * 2 == Sum)
            {
                splitsCount++;
            }
        }

        Console.WriteLine(splitsCount);
    }
}
