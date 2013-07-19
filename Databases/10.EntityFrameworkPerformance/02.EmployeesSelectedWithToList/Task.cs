using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EmployeesSelectedWithToList
{
    class Task
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities entities = new TelerikAcademyEntities();

            Stopwatch slow = new Stopwatch();
            slow.Start();
            SofiaSlow(entities);
            slow.Stop();

            Stopwatch fast = new Stopwatch();

            fast.Start();
            SofiaFast(entities);
            fast.Stop();

            Console.WriteLine("Invoking ToList several times time: {0}", slow.Elapsed);
            Console.WriteLine("Invoking ToList once time: {0}", fast.Elapsed);
        }

        private static void SofiaFast(TelerikAcademyEntities entities)
        {
            List<Employee> employeesFromSofia = 
                (from employee in entities.Employees
                     where employee.Address.Town.Name == "Sofia"
                     select employee).ToList();
        }

        private static void SofiaSlow(TelerikAcademyEntities entities)
        {
            List<Employee> employees =
                entities.Employees.ToList();
            List<Address> addresses =
                employees.Select(emp => emp.Address).ToList();
            List<Town> towns = addresses.Select(ad => ad.Town).ToList();
            List<Town> sofia = towns.Where(t => t.Name == "Sofia").ToList();
        }
    }
}
