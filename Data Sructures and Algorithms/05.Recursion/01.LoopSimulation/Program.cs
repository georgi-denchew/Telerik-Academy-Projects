namespace _01.LoopSimulation
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter nested loops count: ");
            int loopsCount = int.Parse(Console.ReadLine());
            int[] indices = new int[loopsCount];
            int currentIndex = 0;

            Loop(currentIndex, loopsCount, indices);
        }

        private static void Loop(int currentIndex, int loopsCount, int[] indices)
        {
            if (currentIndex >= loopsCount)
            {
                string print = string.Join(", ", indices);
                Console.WriteLine(print);
                return;
            }

            for (int i = 1; i <= loopsCount; i++)
            {
                indices[currentIndex] = i;
                Loop(currentIndex + 1, loopsCount, indices);
            }
        }
    }
}