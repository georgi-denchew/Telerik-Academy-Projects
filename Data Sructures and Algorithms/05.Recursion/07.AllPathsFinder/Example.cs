namespace _07.AllPathsFinder
{
    using System;
    using System.Linq;

    class Example
    {
        static void Main(string[] args)
        {
            PathFinder finder = new PathFinder(4);
            Console.WriteLine("If no paths are shown restart the application - the passable cells are generated"+
                "randomly, so you might have started at an \"unpassable\" cell");
            Console.WriteLine();
            
            finder.PrintMatrix();
            finder.FindAllPaths(0, 0, 3, 3);
            finder.PathExists();
        }
    }
}
