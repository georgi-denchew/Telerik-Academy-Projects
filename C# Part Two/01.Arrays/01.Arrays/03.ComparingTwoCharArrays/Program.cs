using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ComparingTwoCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length here: ");
            int length = int.Parse(Console.ReadLine());
            char[] firstArray = new char[length];
            char[] secondArray = new char[length];

            Console.WriteLine("Enter values for the first array here: ");

            for (int i = 0; i < length; i++)
            {
                firstArray[i] = char.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter values for the second array here: ");

            for (int i = 0; i < length; i++)
            {
                secondArray[i] = char.Parse(Console.ReadLine());
            }

            for (int i = 0; i < length; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    Console.WriteLine("Letters with index {0} are the same.", i);
                }

                else 
                {
                    Console.WriteLine("Letters with index {0} are different.", i);
                }
            }
        }
    }
}
