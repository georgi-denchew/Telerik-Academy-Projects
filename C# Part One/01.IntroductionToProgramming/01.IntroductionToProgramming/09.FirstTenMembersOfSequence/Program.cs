using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FirstTenMembersOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            for (int b = 2; b < 12; b++)
            {
                Console.WriteLine("The first ten members of the sequence are:" + (b * a));
                a *= -1;
            }
        }
    }
}
