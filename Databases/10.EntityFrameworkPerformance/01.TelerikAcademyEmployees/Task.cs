using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TelerikAcademyEmployees
{
    class Task
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities entities = new TelerikAcademyEntities();

            Stopwatch noIncludeWatch = new Stopwatch();
            noIncludeWatch.Start();
            foreach (var employee in entities.Employees)
            {
                Console.WriteLine("Employee Name: {0}; Employee Department: {1}; Employee Town: {2}",
                    employee.FirstName + " " + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }
            noIncludeWatch.Stop();

            Stopwatch includeWatch = new Stopwatch();
            includeWatch.Start();

            foreach (var employee in entities.Employees.Include("Department").Include("Address").Include("Address.Town"))
            {
                Console.WriteLine("Employee Name: {0}; Employee Department: {1}; Employee Town: {2}",
                       employee.FirstName + " " + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }
            includeWatch.Stop();


            Console.WriteLine("No include clauses used time: {0}", noIncludeWatch.Elapsed);
            Console.WriteLine("Include clauses used time: {0}", includeWatch.Elapsed);


            // We make approximately 340 requests without .Include method
            // And only 1 with the .Include method
        }
    }
}