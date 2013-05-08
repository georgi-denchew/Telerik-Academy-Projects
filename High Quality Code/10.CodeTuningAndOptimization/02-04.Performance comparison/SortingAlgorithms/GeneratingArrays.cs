using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class GeneratingArrays
    {
        private static Random rand = new Random();

        public static void GenerateIntArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next();
            }
        }

        public static void GenerateDoubleArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.NextDouble();
            }
        }

        public static void GenerateStringArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next().ToString();
            }
        }

        public static void ReverseArray<T>(T[] array) where T : IComparable
        {
            Array.Sort(array, new Comparison<T>((x, y) => y.CompareTo(x)));
        }
    }
}
