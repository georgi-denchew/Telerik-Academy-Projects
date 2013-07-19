using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreatestOfFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program finds the greatest ot five given variables");
            Console.Write("Enter the first variable here: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Enter the second variable here: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Enter the third variable here: ");
            int third = int.Parse(Console.ReadLine());
            Console.Write("Enter the fourth variable here: ");
            int fourth = int.Parse(Console.ReadLine());
            Console.Write("Enter the fifth variable here: ");
            int fifth = int.Parse(Console.ReadLine());

            if (first >= second && first >= third && first >= fourth && first >= fifth)
            {
                Console.WriteLine("The greatest number is: " + first);
            }

            if (second > first && second >= third && second >= fourth && second >= fifth)
            {
                Console.WriteLine("The greatest number is: " + second);
            }

            if (third > first && third > second && third >= fourth && third >= fifth)
            {
                Console.WriteLine("The greatest number is: " + third);
            }

            if (fourth > first && fourth > second && fourth > third && fourth >= fifth)
            {
                Console.WriteLine("The greatest number is: " + fourth);
            }

            if (fifth > first && fifth > second && fifth > third && fifth > fourth)
            {
                Console.WriteLine("The greatest number is: " + fifth);
            }
        }
    }
}
