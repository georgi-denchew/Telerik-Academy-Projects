using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculatingS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates the sum S = 1 + 1!/X + 2!/X(Powered 2) + … + N!/X(Powered N) for given X and N");
            Console.Write("Enter X here: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter N here: ");
            double n = double.Parse(Console.ReadLine());
            double a = 1;
            double s = 1;
            double tempA = 1;
            while (a <= n)
            {
                tempA = tempA * a;
                s = s + tempA / Math.Pow(x, a);
                a++;
            }
            Console.WriteLine("The sum S is: {0}", s);
        }
    }
}
