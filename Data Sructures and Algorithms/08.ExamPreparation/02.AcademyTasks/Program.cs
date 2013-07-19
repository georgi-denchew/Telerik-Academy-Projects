namespace _02.AcademyTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<int> tasks = new List<int>();
        static int variety;

        static void Main(string[] args)
        {
            string tasksAsStringLine = Console.ReadLine();
            
            variety = int.Parse(Console.ReadLine());
            var tasksAsString = tasksAsStringLine.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var task in tasksAsString)
            {
                tasks.Add(int.Parse(task));
            }

            Console.WriteLine(Solve());
        }

        private static int Solve()
        {
            int minCount = tasks.Count;

            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int count = 0;

                        count += (i + 1) / 2;
                        count += (j - i + 1) / 2 + 1;
                        minCount = Math.Min(minCount, count);
                    }
                }
            }

            return minCount;
        }
    }
}