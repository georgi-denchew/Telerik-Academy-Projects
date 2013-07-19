using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AcademyTasks
{
    class Program
    {

        static List<int> tasks = new List<int>();
        static int variety;

        static void Main(string[] args)
        {

            // 1, 2, 3, 4, 5
            // 3
            string tasksAsStringLine = Console.ReadLine();
            var taskskAsString = tasksAsStringLine.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            foreach (var taskAsString in taskskAsString)
            {
                tasks.Add(int.Parse(taskAsString));
            }

            variety = int.Parse(Console.ReadLine());

            SolveWithDP();

            //    bestSolution = tasks.Count;


            //    //call recursion

            //    Solve(0, 1, tasks[0], tasks[0]);
            //}

            //static int bestSolution = int.MaxValue;

            //static void Solve(int currentIndex, int tasksSolved, int currentMin, int currentMax)
            //{
            //    if (currentMax - currentMin >= variety)
            //    {
            //        bestSolution = Math.Min(bestSolution, tasksSolved);
            //        return;
            //    }

            //    if (currentIndex >= tasks.Count)
            //    {
            //        return;
            //    }

            //    for (int i = 1; i <= 2; i++)
            //    {
            //        if (currentIndex + 1 < tasks.Count)
            //        {
            //            Solve(currentIndex + i, tasksSolved + 1,
            //                        Math.Min(currentMin, tasks[currentIndex + i]),
            //                        Math.Max(currentMax, tasks[currentIndex + i]));
            //        }
            //    }
        }

        private static void SolveWithDP()
        {
            throw new NotImplementedException();
        }
    }
}