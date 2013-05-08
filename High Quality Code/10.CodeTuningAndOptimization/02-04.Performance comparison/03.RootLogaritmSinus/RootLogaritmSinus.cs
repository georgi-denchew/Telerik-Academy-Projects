using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RootLogaritmSinus
{
    class RootLogaritmSinus
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            float f = 123456f;
            double d = 123456d;
            decimal m = 123456m;

            stopwatch.Start();
            Math.Sqrt(f);
            stopwatch.Stop();


            Console.WriteLine("It takes {0} to find square root of floating-point variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Sqrt(d);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find square root of double variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Sqrt((double)m);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find square root of decimal variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Log(f);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find logarithm of floating-point variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Log(d);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find logarithm of double variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Log((double)m);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find logarithm of decimal variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Sin(f);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find the sinus of floating-point variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Sin(d);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find the sinus of double variable", stopwatch.Elapsed);

            stopwatch.Reset();

            stopwatch.Start();
            Math.Sin((double)m);
            stopwatch.Stop();

            Console.WriteLine("It takes {0} to find the sinus of decimal variable", stopwatch.Elapsed);

        }
    }
}
