using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.SequenceOfOperatorModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program modifies a given integer number \"n\" to hold a value v=0 or v=1 at a given position \"p\"");
            Console.Write("Enter integer number here:");
            string integernumber = Console.ReadLine();
            int n;
            int.TryParse(integernumber, out n);
            Console.Write("Enter position here:");
            string position = Console.ReadLine();
            int p;
            int.TryParse(position, out p);
            Console.Write("Enter value of 1 or 0 here:");
            string value = Console.ReadLine();
            int v;
            int.TryParse(value, out v);
            if (v != 0 && v != 1)
            {
                Console.WriteLine("The value you have entered for v is different than 1 or 0");
            }
            else
            {
                if (v == 0)
                {
                    int mask = ~(1 << p);
                    int result = n & mask;
                    Console.WriteLine("The new number is:{0}", result);
                    Console.WriteLine("Binery number:{0}", Convert.ToString(result, 2).PadLeft(32, '0'));
                }
                else
                {
                    int mask = 1 << p;
                    int result = n | mask;
                    Console.WriteLine("The new number is:{0}", result);
                    Console.WriteLine("Binery number:{0}", Convert.ToString(result, 2).PadLeft(32, '0'));
                }
            }
        }
    }
}