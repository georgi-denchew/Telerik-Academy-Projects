using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.IntegerOddOrEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number here: ");
            string number = Console.ReadLine();
            int value;
            int.TryParse(number, out value);
            bool oddoreven = value % 2 == 0;
            Console.WriteLine("Your Number is:{0}", oddoreven? "even" : "odd");


        }
    }
}
