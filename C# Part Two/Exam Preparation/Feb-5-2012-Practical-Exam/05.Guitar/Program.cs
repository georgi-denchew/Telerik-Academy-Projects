using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5_Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] volumesStr = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int startVolume = int.Parse(Console.ReadLine());
            int maxVolume = int.Parse(Console.ReadLine());
            int[] volumes = new int[volumesStr.Length];
            for (int i = 0; i < volumes.Length; i++)
            {
                volumes[i] = int.Parse(volumesStr[i]);
            }

            Console.WriteLine(Answer(volumes, startVolume, maxVolume));
        }

        private static int Answer(int[] volumes, int startVolume, int maxVolume)
        {
            int n = volumes.Length;
            int[,] usedVolumes = new int[n + 1, maxVolume + 1];
            usedVolumes[0, startVolume] = 1;

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 0; j < maxVolume + 1; j++)
                {
                    if (usedVolumes[i - 1, j] == 1)
                    {
                        int x = volumes[i - 1];
                        if (j - x >= 0)
                        {
                            usedVolumes[i, j - x] = 1;
                        }
                        if (j + x <= maxVolume)
                        {
                            usedVolumes[i, j + x] = 1;
                        }
                    }
                }
            }

            for (int i = maxVolume; i > 0; i--)
            {
                if (usedVolumes[n, i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
