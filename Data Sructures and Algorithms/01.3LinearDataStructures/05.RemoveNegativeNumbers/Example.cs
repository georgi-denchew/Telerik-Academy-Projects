namespace _05.RemoveNegativeNumbers
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
            sequence.Add(-2); 
            sequence.Add(1);
            sequence.Add(-2); 
            sequence.Add(-8);
            sequence.Add(1);
            sequence.Add(-2); 
            sequence.Add(1);
            sequence.Add(-3);
            sequence.Add(-2);

            List<int> positivesSequence = sequence.Where(x => x > 0).ToList();

            // Method PrintSequence can be found in the 00.Methods project.
            Methods.PrintSequence(positivesSequence);
        }
    }
}
