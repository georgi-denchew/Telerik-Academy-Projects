using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StringSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string here: ");
            string[] input = Console.ReadLine().Split(' ');
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += int.Parse(input[i].Trim());
            }

            Console.WriteLine(sum);
        }
    }
}
