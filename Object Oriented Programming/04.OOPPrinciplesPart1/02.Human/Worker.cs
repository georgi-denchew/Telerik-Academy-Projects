using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
        {
            base.firstName = firstName;
            base.lastName = lastName;
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public int WeekSalary
        {
            get { return this.weekSalary; }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
        }

        public decimal MoneyPerHour() // let's say the a worker works 5 days per week
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

    }
}
