﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SortingUsingMergeSortAlgorithm
{
    class Program
    {
        static int[] MergeArrays(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int leftIncrease = 0;
            int rightIncrease = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (rightIncrease == right.Length || ((leftIncrease < left.Length) && (left[leftIncrease] <= right[rightIncrease])))
                {
                    result[i] = left[leftIncrease];
                    leftIncrease++;
                }

                else if (leftIncrease == left.Length || ((rightIncrease < right.Length) && (right[rightIncrease] <= left[leftIncrease])))
                {
                    result[i] = right[rightIncrease];
                    rightIncrease++;
                }
            }
            return result;
        }

        static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[array.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                leftArray[i] = array[i];
            }

            for (int i = middle, j = 0; i < array.Length; i++, j++)
            {
                rightArray[j] = array[i];
            }

            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);

            return MergeArrays(leftArray, rightArray);
        }

        static void PrintArr(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arrrayOfIntegers = { 1, 5, 7, 8, 9, 3, 5, 6, 7 };
            int[] sortedArray = MergeSort(arrrayOfIntegers);

            PrintArr(sortedArray);
        }
    }
}
