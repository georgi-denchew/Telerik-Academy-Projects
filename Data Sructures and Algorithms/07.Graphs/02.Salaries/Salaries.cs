// Class not in separate file to ease bgcoder.com testing

namespace _02.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Salaries
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());

            Dictionary<int, Employee> allEmployees = new Dictionary<int, Employee>();

            for (int i = 0; i < employeesCount; i++)
            {
                allEmployees.Add(i, new Employee(i));
            }

            for (int i = 0; i < employeesCount; i++)
            {
                string connetions = Console.ReadLine();

                for (int j = 0; j < connetions.Length; j++)
                {
                    if (connetions[j] == 'Y')
                    {
                        allEmployees[i].AddSubordinate(allEmployees[j]);
                    }
                }
            }

            long salaries = 0;

            foreach (var node in allEmployees)
            {
                salaries += node.Value.CalculateSalary();                
            }

            Console.WriteLine(salaries);
        }
    }

    public class Employee
    {
        public Employee(int id)
        {
            this.ID = id;
            this.Subordinates = new List<Employee>();
        }

        public long Salary { get ; set; }

        public long CalculateSalary()
        {
            if (this.Subordinates.Count == 0)
            {
                this.Salary = 1;
                return this.Salary;
            }

            if (this.Salary > 1)
            {
                return this.Salary;
            }

            long result = 0;

            foreach (var subordinate in this.Subordinates)
            {
                result += subordinate.CalculateSalary();
            }

            this.Salary = result;
            return result;
        }

        public int ID { get; private set; }

        public List<Employee> Subordinates { get; set; }

        internal void AddSubordinate(Employee node)
        {
            this.Subordinates.Add(node);
        }
    }
}
