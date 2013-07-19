using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IntDoubleOrString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program shows entered integer, double or string");
            Console.WriteLine("Enter 1 for integer, 2 for double and 3 for string");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter integer number here: ");
                    int integer = int.Parse(Console.ReadLine());
                    int result = integer + 1;
                    Console.WriteLine("The integer result is: " + result);
                    break;
                case 2:
                    Console.WriteLine("Enter double number here: ");
                    double d = double.Parse(Console.ReadLine());
                    double dresult = d + 1;
                    Console.WriteLine("The double result is: " + dresult);
                    break;
                case 3:
                    Console.WriteLine("Enter string here: ");
                    string str = Console.ReadLine();
                    string star = "*";
                    string sresult = str + star;
                    Console.WriteLine("The string result is: " + sresult);
                    break;

            }
        }
    }
}
