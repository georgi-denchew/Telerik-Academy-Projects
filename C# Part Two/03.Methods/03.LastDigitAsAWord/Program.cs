using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LastDigitAsAWord
{
    class Program
    {
        static string Word(int n)
        {
            string number = Convert.ToString(n);
            string last = Convert.ToString(number[number.Length - 1]);
            int lastDigit = 0;
            int.TryParse(last, out lastDigit);
            switch (lastDigit)
            {
                case 0:
                    {
                        return "Zero";
                    }
                case 1:
                    {
                        return "One";
                    }
                case 2:
                    {
                        return "Two";
                    }
                case 3:
                    {
                        return "Three";
                    }
                case 4:
                    {
                        return "Four";
                    }
                case 5:
                    {
                        return "Five";
                    }
                case 6:
                    {
                        return "Six";
                    }
                case 7:
                    {
                        return "Seven";
                    }
                case 8:
                    {
                        return "Eight";
                    }
                case 9:
                    {
                        return "Nine";
                    }
                default:
                    {
                        return "Not a valid number";
                    }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number here: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Word(n));
        }
    }
}
