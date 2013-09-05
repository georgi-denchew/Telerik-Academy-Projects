using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a new instance of the Deque class
            Deque<string> people = new Deque<string>();

            // Pushes a string at the start of the deque
            people.PushFirst("Peter");

            // Pushes a string at the end of the deque
            people.PushLast("George");

            people.PushFirst("Tom");

            people.PushLast("John");

            // The output result will be: 4
            Console.WriteLine(people.Count);

            string p1 = people.PeekFirst();

            // The output result will be: Tom 
            Console.WriteLine(p1);

            string p2 = people.PopFirst();

            // The output result will be: Tom
            Console.WriteLine(p2);

            // The output result will be: 3
            Console.WriteLine(people.Count);

            string p3 = people.PeekLast();

            // The output result will be John
            Console.WriteLine(p3);

            string p4 = people.PopLast();

            // The output result will be: John
            Console.WriteLine(p4);

            // The output result will be: 2
            Console.WriteLine(people.Count);

            bool containsPeter = people.Contains("Peter");

            // The output result will be: true
            Console.WriteLine(containsPeter);

            people.Clear();

            // The output result will be 0
            Console.WriteLine(people.Count);
        }
    }
}
