using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BonusScores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program adds bonus to scores in the range [1,9]");
            Console.WriteLine("Enter the score here: ");
            int score = int.Parse(Console.ReadLine());
            switch (score)
            {
                case 0:
                    Console.WriteLine("Please, enter a digit different than zero.");
                    break;
                case 1:
                    int result = score * 10;
                    Console.WriteLine("The result is: " + result);
                    break;
                case 2:
                    int result2 = score * 10;
                    Console.WriteLine("The result is: " + result2);
                    break;
                case 3:
                    int result3 = score * 10;
                    Console.WriteLine("The result is: " + result3);
                    break;
                case 4:
                    int result4 = score * 100;
                    Console.WriteLine("The result is: " + result4);
                    break;
                case 5:
                    int result5 = score * 100;
                    Console.WriteLine("The result is: " + result5);
                    break;
                case 6:
                    int result6 = score * 100;
                    Console.WriteLine("The result is: " + result6);
                    break;
                case 7:
                    int result7 = score * 1000;
                    Console.WriteLine("The result is: " + result7);
                    break;
                case 8:
                    int result8 = score * 1000;
                    Console.WriteLine("The result is: " + result8);
                    break;
                case 9:
                    int result9 = score * 1000;
                    Console.WriteLine("The result is: " + result9);
                    break;
                default:
                    Console.WriteLine("Prease enter a valid digit different than zero");
                    break;
                    
            }
        }
    }
}
