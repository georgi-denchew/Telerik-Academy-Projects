namespace _09.LargestEmptyCellArea
{
    using System;
    using System.Linq;

    class Example
    {
        static void Main(string[] args)
        {
            EmptyCellsFinder finder = new EmptyCellsFinder(6, 4);
            finder.FindLargestEmptyCellArea();
        }
    }
}
