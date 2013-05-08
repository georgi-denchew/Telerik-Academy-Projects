using System;

namespace _03.LoopRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            int expectedValue = 30;
            bool expectedValueFound = false;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);

                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        expectedValueFound = true;
                        break; // assigning 666 to "i" will stop the loop
                    }
                }
                else
                {
                    continue;
                }
            }

            // Instead of checking if the loop was stopped prematurely by checking the value of "i",
            // the check should be performed by a boolean variable
            if (expectedValueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
