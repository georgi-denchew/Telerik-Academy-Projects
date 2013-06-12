namespace _08.MajorantFinder
{
    using _00.Methods;
    using System;

    class Example
    {
        static void Main(string[] args)
        {
            int[] array = new int[9] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            //Example --> The methods are in 00.Methods Project
            int majorant = Methods.FindMajorant(array);

            Console.WriteLine("The majorant is {0}", majorant);
        }
    }
}
