using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _07.Timer
{
    //TASK 07: Using delegates write a class Timer that can
    //execute certain method at each t seconds.

    public delegate void Delegate(string str, int t);


    public class Examples
    {
        static void Method(string str, int t)
        {
            Console.WriteLine(str);
            Thread.Sleep(t);
            Method(str, t);
        }


        static void Main()
        {
            Console.Write("Enter t milliseconds here: ");
            int t = int.Parse(Console.ReadLine());
            string str = "Hello, World!";

            Delegate del = (Method);

            del(str, t);

        }
    }
}
