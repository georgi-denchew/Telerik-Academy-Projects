using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FirmEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstName = "Pesho";
            string FamilyName = "Peshev";
            byte Age = 20;
            dynamic Gender = '\u006d';
            uint IDNumber = 123456789;
            uint EmployeeNumber = 27561234;
            Console.WriteLine("First Name:" + FirstName);
            Console.WriteLine("Family Name:" + FamilyName);
            Console.WriteLine("Age:" + Age);
            Console.WriteLine("Gender:" + Gender);
            Console.WriteLine("ID Number:" + IDNumber);
            Console.WriteLine("Employee Number:" + EmployeeNumber);
    }
    }
}