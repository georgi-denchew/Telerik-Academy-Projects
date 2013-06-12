using System;

class Program
{
    static void Main()
    {
        SimpleClass simple = new SimpleClass(1, 2, 3, 4);
        Console.WriteLine(simple.Sum());
    }
}