using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentNames
{
    public static class Methods
    {
        public static Student[] Names(this Student[] students) //TASK 03
        {
            var names =
                from student in students
                where student.Name.Split(' ')[0].CompareTo(student.Name.Split(' ')[1]) == -1
                select student;

            Student[] result = names.ToArray();
            return result;
        }

        public static Student[] Ages(this Student[] students) //TASK 04
        {
            var ages =
                from student in students
                where (student.Age >= 18 && student.Age <= 24)
                select student;
            Student[] result = ages.ToArray();
            return result;
        }

        public static Student[] SortedLinq(this Student[] students) //TASK 05 - LINQ
        {
            var sorted =
                from student in students
                orderby student.Name.Split(' ')[0] descending, student.Name.Split(' ')[1] descending
                select student;
            return sorted.ToArray();
        }
        
    }
}
