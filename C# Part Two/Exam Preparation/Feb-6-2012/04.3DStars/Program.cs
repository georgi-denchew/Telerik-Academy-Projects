using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._3DStars
{
    class Program
    {
        static void Main(string[] args)
        {
            string whd = Console.ReadLine();
            string[] sizes = whd.Split();
            int width = int.Parse(sizes[0]);
            int height = int.Parse(sizes[1]);
            int depth = int.Parse(sizes[2]);
            char[, ,] cuboid = new char[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] letters = line.Split();
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cuboid[w, h, d] = letters[d][w];
                    }
                }
            }
            int starCount = 0;
            char[] letterCount = new char['Z' - 'A' + 1];
            for (int w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    for (int d = 1; d < depth - 1; d++)
                    {
                        if (cuboid[w, h, d] == cuboid[w + 1, h, d] &&
                            cuboid[w, h, d] == cuboid[w - 1, h, d] &&
                            cuboid[w, h, d] == cuboid[w, h + 1, d] &&
                            cuboid[w, h, d] == cuboid[w, h - 1, d] &&
                            cuboid[w, h, d] == cuboid[w, h, d + 1] &&
                            cuboid[w, h, d] == cuboid[w, h, d - 1])
                        {
                            starCount++;
                            letterCount[cuboid[w, h, d] - 'A']++;
                        }
                    }
                }
            }
            Console.WriteLine(starCount);
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                int count = letterCount[letter - 'A'];
                if (count > 0)
                {
                    Console.WriteLine("{0} {1}", letter, count);
                }
            }
        }
    }
}
