namespace _08.PathChecker
{
    using System;
    using System.Linq;

    class Example
    {
        static void Main(string[] args)
        {
            // The program generates random passable cells
            // Run multiple times to test different cases

            PatchChecker finder = new PatchChecker(100);

            // for the program to work with a matrix of size 100
            // the path checking must be
            // performed iteratively, not recursivly
            // If we use recursion it hangs!!!

            finder.PrintMatrix();
            finder.FindAllPaths(0, 0, 99, 99);
            finder.PathExists();
        }
    }
}
