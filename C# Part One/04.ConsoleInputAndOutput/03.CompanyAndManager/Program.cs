using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyAndManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program shows entered information about a company and it's manager");
            Console.Write("Enter company name:");
            string companyname = Console.ReadLine();
            Console.Write("Enter company address:");
            string address = Console.ReadLine();
            Console.Write("Enter company phone number:");
            int companynumber = int.Parse(Console.ReadLine());
            Console.Write("Enter company fax number");
            int companyfax = int.Parse(Console.ReadLine());
            Console.Write("Enter company web site:");
            string website = Console.ReadLine();
            Console.Write("Enter company manager:");
            string manager = Console.ReadLine();
            Console.Write("Enter the manager's first name:");
            string firstname = Console.ReadLine();
            Console.Write("Enter the manager's last name:");
            string lastname = Console.ReadLine();
            Console.Write("Enter the manager's age:");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the manager's phone number:");
            int managernumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Company name: " + companyname);
            Console.WriteLine("Company address: " + address);
            Console.WriteLine("Company phone number: " + companynumber);
            Console.WriteLine("Company fax number: " + companyfax);
            Console.WriteLine("Company manager: " + manager);
            Console.WriteLine("Manager's first name: " + firstname);
            Console.WriteLine("Manager's last name: " + lastname);
            Console.WriteLine("Manager's age: " + age);
            Console.WriteLine("Manager's phone number: " + managernumber);
        }
    }
}
