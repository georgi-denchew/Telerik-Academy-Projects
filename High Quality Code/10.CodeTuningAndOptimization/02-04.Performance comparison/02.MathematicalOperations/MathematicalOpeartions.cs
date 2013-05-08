using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MathematicalOperations
{
    class MathematicalOpeartions
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            
            
            int i = 1234;
            long l = 1234;
            float f = 1234;
            decimal d = 1234;


            watch.Start();
            l += l;
            watch.Stop();
            Console.WriteLine("It takes {0} to add long variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            i += i;
            watch.Stop();
            Console.WriteLine("It takes {0} to add integer variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            f += f;
            watch.Stop();
            Console.WriteLine("It takes {0} to add floating-point variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            d += d;
            watch.Stop();
            Console.WriteLine("It takes {0} to add decimal variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            l *= l;
            watch.Stop();
            Console.WriteLine("It takes {0} to multiply long variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            i *= i;
            watch.Stop();
            Console.WriteLine("It takes {0} to multiply integer variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            f *= f;
            watch.Stop();
            Console.WriteLine("It takes {0} to multiply floating-point variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            d *= d;
            watch.Stop();
            Console.WriteLine("It takes {0} to multiply decimal variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            l -= 1000;
            watch.Stop();
            Console.WriteLine("It takes {0} to substract long variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            i -= 1000;
            watch.Stop();
            Console.WriteLine("It takes {0} to substract integer variables", watch.Elapsed);

            watch.Reset();


            watch.Start();
            f -= 1000;
            watch.Stop();
            Console.WriteLine("It takes {0} to substract floating-point variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            d -= 1000;
            watch.Stop();
            Console.WriteLine("It takes {0} to substract decimal variables", watch.Elapsed);

            watch.Reset();
            watch.Start();
            l /= 5;
            watch.Stop();
            Console.WriteLine("It takes {0} to divide long variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            i /= 5;
            watch.Stop();
            Console.WriteLine("It takes {0} to divide integer variables", watch.Elapsed);

            watch.Reset();


            watch.Start();
            f /= 5;
            watch.Stop();
            Console.WriteLine("It takes {0} to divide floating-point variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            d /= 5;
            watch.Stop();
            Console.WriteLine("It takes {0} to divide decimal variables", watch.Elapsed);

            watch.Reset();

            watch.Start();
            
            for (l = 0; l < 10000; l++)
            {
            }

            watch.Stop();

            Console.WriteLine("It takes {0} to increment long variables", watch.Elapsed);

            watch.Reset();

            watch.Start();

            for (i = 0; i < 10000; i++)
            {
            }

            watch.Stop();

            Console.WriteLine("It takes {0} to increment int variables", watch.Elapsed);

            watch.Reset();

            watch.Start();

            for (f = 0; f < 10000; f++)
            {
            }

            watch.Stop();

            Console.WriteLine("It takes {0} to increment floating-point variables", watch.Elapsed);

            watch.Reset();

            watch.Start();

            for (d = 0; d < 10000; d++)
            {
            }

            watch.Stop();

            Console.WriteLine("It takes {0} to increment decimal variables", watch.Elapsed);

            watch.Reset();
        }
    }
}
