using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReadInteger
{
    class Program
    {
        static void CheckIfNegatie(int n)
        {
            if (n < 0)
                throw new FormatException();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");

            try
            {
                int n = int.Parse(Console.ReadLine());
                CheckIfNegatie(n);
                Console.WriteLine(Math.Sqrt(n));

            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid number!");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Invalid number!");
            }

            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
