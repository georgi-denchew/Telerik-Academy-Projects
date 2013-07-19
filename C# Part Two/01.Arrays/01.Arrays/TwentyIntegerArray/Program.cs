using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyIntegerArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] TwentyIntegerArray = new int[20];

            for (int i = 0; i < TwentyIntegerArray.Length; i++)
            {
                TwentyIntegerArray[i] = i * 5;
                Console.Write(TwentyIntegerArray[i] + " ");
            }
        }
    }
}