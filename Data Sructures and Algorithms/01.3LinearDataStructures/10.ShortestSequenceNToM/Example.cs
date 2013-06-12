namespace _10.ShortestSequenceNToM
{
    using System;

    public class Example
    {
        static void Main(string[] args)
        {
            SequenceFinder finder = new SequenceFinder(
                int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            
            finder.FindShortestSequences();
            finder.PrintSequence();
        }
    }
}
