using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.IsGivenNumberPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number less than 101 here: ");
            string EnteredNumber = Console.ReadLine();
            int n;
            int.TryParse(EnteredNumber, out n);
            if (n <= 100)
            {
                if (n != 2 && n != 3 && n != 5 && n != 7)
                {
                    bool check = n % 2 != 0 && n % 3 != 0 && n % 5 != 0 && n % 7 != 0;
                    Console.WriteLine(check ? "Your number is prime" : "Your number isn't prime");
                }
                else
                {
                    Console.WriteLine("Your number is prime");
                }
            }
            else
            {
                Console.WriteLine("Your number is larger than 100");
            }
        }
    }
}
