using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ADTStackImplementation
{
    class Example
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Dequeue();

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            
            //Capacity increase example
            stack.Push(3);
            stack.Push(4);
            
            //Remove example
            stack.Pop();
            //More capacity increase examples
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
        }
    }
}
