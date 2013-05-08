using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Examples
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            int[] intArr = new int[1000];
            double[] doubleArr = new double[1000];
            string[] stringArr = new string[1000];

            stopwatch.Start();
            GeneratingArrays.GenerateIntArray(intArr);
            stopwatch.Stop();
            
            Console.WriteLine("It takes {0} to generate a random int array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            GeneratingArrays.GenerateDoubleArray(doubleArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to generate a random double array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            GeneratingArrays.GenerateStringArray(stringArr); ;
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to generate a random string array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.InsertionSort(intArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Insertion Sort algorigthm int array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.InsertionSort(doubleArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Insertion Sort algorigthm double array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.InsertionSort(stringArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Insertion Sort algorigthm string array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.QuickSort(intArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Quick Sort algorigthm int array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.QuickSort(doubleArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Quick Sort algorigthm double array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.QuickSort(stringArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Quick Sort algorigthm string array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.SelectionSort(intArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Selection Sort algorigthm int array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.SelectionSort(doubleArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Selection Sort algorigthm double array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            SortingAlgorithms.SelectionSort(stringArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to sort using Selection Sort algorigthm string array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            GeneratingArrays.ReverseArray(intArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to reverse-sort int array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            GeneratingArrays.ReverseArray(doubleArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to reverse-sort double array", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            GeneratingArrays.ReverseArray(stringArr);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to reverse-sort string array", stopwatch.Elapsed);

            stopwatch.Reset();
        }
    }
}
