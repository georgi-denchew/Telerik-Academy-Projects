namespace _06.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _00.Methods;

    class Example
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            sequence.Add(4);
            sequence.Add(2);
            sequence.Add(2);
            sequence.Add(5);
            sequence.Add(2);
            sequence.Add(3);
            sequence.Add(2);
            sequence.Add(3);
            sequence.Add(1);
            sequence.Add(5);
            sequence.Add(2);


            sequence = RemoveOddOccurences(sequence);

            // Method PrintSequence can be found in the 00.Methods project.
            Methods.PrintSequence(sequence);
        }

        public static List<int> RemoveOddOccurences(List<int> sequence)
        {

            return sequence.FindAll(x => (sequence.Count(y => y == x)) % 2 == 0);           
        }
    }
}
