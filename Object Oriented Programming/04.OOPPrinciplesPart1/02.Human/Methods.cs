using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public static class Methods
    {
        public static List<Student> StudentsGradeSort(this List<Student> students)
        {
            var sorted =
                from student in students
                orderby student.Grade ascending
                select student;
            return sorted.ToList();
        }

        public static List<Worker> WorkersMoneyPerHour(this List<Worker> workers)
        {
            var sorted =
                from worker in workers
                orderby worker.MoneyPerHour() descending
                select worker;
            return sorted.ToList();
        }

        public static List<Human> NameOrder(this List<Human> humans)
        {
            var sorted =
                from human in humans
                orderby human.FirstName, human.LastName
                select human;
            return sorted.ToList();
        }
    }
}
