namespace _05.HashSetImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Examples
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(10);
            
            set.Remove(10);

            Console.WriteLine("First set count: {0}", set.Count);
            Console.WriteLine();

            HashSet<int> secondSet = new HashSet<int>();
            secondSet.Add(1);
            secondSet.Add(6);
            secondSet.Add(5);
            secondSet.Add(4);

            IEnumerable<int> unioned = set.Union(secondSet);
            Console.WriteLine("Unioned set:");

            foreach (var item in unioned)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Intersected set:");
            IEnumerable<int> intersected = set.Intersect(secondSet);

            foreach (var item in intersected)
            {
                Console.WriteLine(item);
            }
        }
    }
}
