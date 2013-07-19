using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ConvertingNumberToText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program converts a number in the interval [0, 999] to a text corresponding to its pronunciation");
            Console.WriteLine("Enter the first digit of the number here: ");
            int first = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second digit of the number here: ");
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the third digit of the number here: ");
            int third = int.Parse(Console.ReadLine());

            if (first < 0 || first > 9 || second < 0 || second > 9 || third < 0 || third > 9)
            {
                Console.WriteLine("Please enter valid digits");
            }
            else
            {
                Console.WriteLine("The number is: ");
                switch (first)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("One hundred ");
                        break;
                    case 2:
                        Console.Write("Two hundred ");
                        break;
                    case 3:
                        Console.Write("Three hundred ");
                        break;
                    case 4:
                        Console.Write("Four hundred ");
                        break;
                    case 5:
                        Console.Write("Five hundred ");
                        break;
                    case 6:
                        Console.Write("Six hundred ");
                        break;
                    case 7:
                        Console.Write("Seven hundred ");
                        break;
                    case 8:
                        Console.Write("Eight hundred ");
                        break;
                    case 9:
                        Console.Write("Nine hundred ");
                        break;

                }
                if (second < 2 && first !=0 && third !=0)
                {
                    Console.Write("and ");
                }
                switch (second)
                {
                    case 0:
                        switch (third)
                        {
                            case 0:
                                if (first == 0 && second == 0)
                                {
                                    Console.WriteLine("zero");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }
                                break;
                            case 1:
                                Console.WriteLine("one");
                                break;
                            case 2:
                                Console.WriteLine("two");
                                break;
                            case 3:
                                Console.WriteLine("three");
                                break;
                            case 4:
                                Console.WriteLine("four");
                                break;
                            case 5:
                                Console.WriteLine("five");
                                break;
                            case 6:
                                Console.WriteLine("six");
                                break;
                            case 7:
                                Console.WriteLine("seven");
                                break;
                            case 8:
                                Console.WriteLine("eight");
                                break;
                            case 9:
                                Console.WriteLine("nine");
                                break;

                        }
                        break;
                    case 1:
                        switch (third)
                        {
                            case 0:
                                Console.WriteLine("ten");
                                break;
                            case 1:
                                Console.WriteLine("eleven");
                                break;
                            case 2:
                                Console.WriteLine("twelve");
                                break;
                            case 3:
                                Console.WriteLine("thirteen");
                                break;
                            case 4:
                                Console.WriteLine("fourteen");
                                break;
                            case 5:
                                Console.WriteLine("fifteen");
                                break;
                            case 6:
                                Console.WriteLine("sixteen");
                                break;
                            case 7:
                                Console.WriteLine("seventeen");
                                break;
                            case 8:
                                Console.WriteLine("eighteen");
                                break;
                            case 9:
                                Console.WriteLine("nineteen");
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("twenty");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 3:
                        Console.Write("thirty");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 4:
                        Console.Write("forty");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 5:
                        Console.Write("fifty");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 6:
                        Console.Write("sixty");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 7:
                        Console.Write("seventy");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 8:
                        Console.Write("eighty");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                    case 9:
                        Console.Write("ninety");
                        switch (third)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.WriteLine(" one");
                                break;
                            case 2:
                                Console.WriteLine(" two");
                                break;
                            case 3:
                                Console.WriteLine(" three");
                                break;
                            case 4:
                                Console.WriteLine(" four");
                                break;
                            case 5:
                                Console.WriteLine(" five");
                                break;
                            case 6:
                                Console.WriteLine(" six");
                                break;
                            case 7:
                                Console.WriteLine(" seven");
                                break;
                            case 8:
                                Console.WriteLine(" eight");
                                break;
                            case 9:
                                Console.WriteLine(" nine");
                                break;
                        }
                        break;
                }

                
            }
        }
    }
}