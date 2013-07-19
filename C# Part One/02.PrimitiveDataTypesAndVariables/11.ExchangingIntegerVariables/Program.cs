using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ExchangingIntegerVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int x;
            x = a;
            a = b;
            b = x;
            Console.WriteLine("This is a:{0}", a);
            Console.WriteLine("Ths is b:{0}", b);
        }
    }
}
