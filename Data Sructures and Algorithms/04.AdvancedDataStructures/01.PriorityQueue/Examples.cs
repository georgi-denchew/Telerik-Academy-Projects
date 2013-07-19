using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    class Examples
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> numbers = new PriorityQueue<int>();
            numbers.Push(1);
            numbers.Push(2);
            numbers.Push(3);
            numbers.Push(4);
            numbers.Push(5);
            numbers.Push(6);
            numbers.Push(7);
            numbers.Push(8);
            numbers.Push(9);
            numbers.Push(10);

            Console.WriteLine("First priority queue:");
            while (numbers.Size > 0)
            {
                Console.WriteLine("{0}", numbers.Pop());
            }
        }
    }
}
