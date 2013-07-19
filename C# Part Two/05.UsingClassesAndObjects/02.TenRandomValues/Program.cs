using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TenRandomValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int randomNumber = rand.Next(200) + 1;
                Console.Write("{0} ", randomNumber);
            }
        }
    }
}
