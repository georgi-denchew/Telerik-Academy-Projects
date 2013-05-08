using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PrintStatictis
{
    class Program
    {

        /// <summary>
        /// I know the statements can be put inside only one loop,
        /// but the task here is to find suitable positions for
        /// the initilizaion and usage variables.
        /// </summary>
        public static void PrintStatistic(double[] arr, int count)
        {
            double maxValue = double.MinValue;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }

            Console.WriteLine(maxValue);

            double minValue = double.MaxValue;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            Console.WriteLine(minValue);

            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            double averageValue = sum / count;
            Console.WriteLine(averageValue);
        }


        static void Main(string[] args)
        {
            double[] arr = new double[100];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            PrintStatistic(arr, 41);
        }
    }
}
