using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentNames
{
    //TASK 03: Write a method that from a given array of students finds all
    //students whose first name is before its last name alphabetically. 
    //Use LINQ query operators.

    //TASK 04: Write a LINQ query that finds the first name and last name of 
    //all students with age between 18 and 24.

    //TASK 05: Using the extension methods OrderBy() and ThenBy() with lambda 
    //expressions sort the students by first name and last name in descending order. 
    //Rewrite the same with LINQ.


    class Examples
    {
        static void Main(string[] args)
        {


            Student student1 = new Student("Aleksandar Borisov", 17);
            Student student2 = new Student("Boris Borisov", 18);
            Student student3 = new Student("Boris Aleksandrov", 23);
            Student student4 = new Student("Dimitar Stefanov", 24);
            Student student5 = new Student("Orlin Todorov", 25);
            Student[] allStudents = new Student[] { student5, student2, student4, student3, student1 };

            foreach (Student student in allStudents.Names()) //TASK 03
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine();

            foreach (Student student in allStudents.Ages()) //TASK 04
            {
                Console.WriteLine("{0} {1}", student.Name, student.Age);
            }
            Console.WriteLine();

            var sortedLambda = allStudents.OrderByDescending(student => student.Name.Split(' ')[0]).ThenByDescending(student => student.Name.Split(' ')[1]);

            foreach (var sorted in sortedLambda) //TASK 05 - LAMBDA
            {
                Console.WriteLine(sorted.Name + " " + sorted.Age);
            }
            Console.WriteLine();

            foreach (var student in allStudents.SortedLinq()) //TASK 05 - LINKQ
            {
                Console.WriteLine(student.Name + " " + student.Age);
            }

        }
    }
}
