using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SortingAlgorithms
    {
        public static void QuickSort<T>(T[] array) where T : IComparable
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort<T>(T[] array, int left, int right) where T : IComparable
        {
            int i = left;
            int j = right;
            T x = array[(left + right) / 2];
            T temp;

            do
            {
                while (array[i].CompareTo(x) < 0 && i < right)
                {
                    i++;
                }

                while (array[j].CompareTo(x) > 0 && j > left)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left > j)
            {
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }

        }

        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minPosition = i;

                for (int j = i; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minPosition]) < 0)
                    {
                        minPosition = j;
                    }
                }

                T temp = array[i];
                array[i] = array[minPosition];
                array[minPosition] = temp;
            }
        }

        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            T temp;
            int k;

            for (int i = 1; i < array.Length; i++)
            {
                temp = array[i];
                k = i - 1;

                while (k >= 0 && array[k].CompareTo(temp) > 0)
                {
                    array[k + 1] = array[k];
                    k--;
                }

                array[k + 1] = temp;
            }
        }
    }
}
