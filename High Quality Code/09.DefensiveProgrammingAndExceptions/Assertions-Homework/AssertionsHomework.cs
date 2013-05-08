using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Cannot sort null array!");

        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 0; i < arr.Length - 2; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Array sort is incorrect!");
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be null!");

        bool startIndexInRange = startIndex >= 0 && (startIndex <= arr.Length - 1);
        Debug.Assert(startIndexInRange, "Start index is out of the array range");

        bool endIndexInRange = endIndex >= 0 && (endIndex <= arr.Length - 1);
        Debug.Assert(endIndexInRange, "End index is out of the array range");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        for (int i = startIndex; i < endIndex; i++)
        {
            Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, "Result element is not the smallest one!");
        }

        Debug.Assert(minElementIndex <= arr.Length - 1, "Min elemenet index is out of the array range");
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be null!");
        Debug.Assert(value != null, "Value cannot be null!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be null!");
        Debug.Assert(value != null, "Value cannot be null!");

        Debug.Assert(endIndex > startIndex, "Search cannot be started if start index is larger than end index");

        bool startIndexInRange = startIndex >= 0 && startIndex <= arr.Length - 1;
        Debug.Assert(startIndexInRange, "Start index is out the array range");

        bool endIndexInRange = endIndex >= 0 && endIndex <= arr.Length - 1;
        Debug.Assert(endIndexInRange, "End index is out ot the array range");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            Debug.Assert(midIndex >= startIndex, "Middle index should be larger than start index");
            Debug.Assert(midIndex <= endIndex, "Middle index should be smaller than end index");

            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));

    }
}
