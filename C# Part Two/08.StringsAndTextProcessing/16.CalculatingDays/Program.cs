using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _16.CalculatingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first date: ");
            string first = Console.ReadLine();
            Console.Write("Enter second date: ");
            string second = Console.ReadLine();
            string[] one = first.Split('.');
            int dayOne = int.Parse(one[0]);
            int monthOne = int.Parse(one[1]);
            int yearOne = int.Parse(one[2]);
            DateTime date1 = new DateTime(yearOne, monthOne, dayOne);
            string[] two = second.Split('.');
            int dayTwo = int.Parse(two[0]);
            int monthTwo = int.Parse(two[1]);
            int yearTwo = int.Parse(two[2]);
            DateTime date2 = new DateTime(yearTwo, monthTwo, dayTwo);
            Console.WriteLine("Distance: {0} days", Math.Abs((date2 - date1).Days));
            
        }
    }
}
