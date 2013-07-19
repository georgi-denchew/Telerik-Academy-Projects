using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ZeroReminderOfDivisionByFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program shows how many are the numbers that have a reminder of 0 when divided by 5 between the two entered numbers");
            Console.Write("Enter the first number here: ");
            int first = int.Parse(Console.ReadLine());
            if (first <= 0)
            {
                Console.WriteLine("Please enter a positive number");
            }
            else
            {
                Console.Write("Enter the second number here: ");
                int second = int.Parse(Console.ReadLine());
                if (second <= 0)
                {
                    Console.WriteLine("Please enter a positive number");
                }
                else
                {
                    int result = 0;
                    for (int a = first; a <= second; a++) 
                    {
                        
                        if (a % 5 == 0)
                        {
                            result++;
                            
                        }
                    }
                    Console.WriteLine(result);
                    }
                }
            }
        }
    }
