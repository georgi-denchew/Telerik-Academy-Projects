using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    //Define abstract class Human with first name and last name.
    //Define new class Student which is derived from Human 
    //and has new field – grade. Define class Worker derived 
    //from Human with new property WeekSalary and WorkHoursPerDay
    //and method MoneyPerHour() that returns money earned by
    //hour by the worker. Define the proper constructors and 
    //properties for this hierarchy. Initialize a list of 10
    //students and sort them by grade in ascending order 
    //(use LINQ or OrderBy() extension method). Initialize a 
    //list of 10 workers and sort them by money per hour in 
    //descending order. Merge the lists and sort them by first
    //name and last name.

    class Examples
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Student student1 = new Student("Aleksandar", "Aleksandrov", 1);
            Student student2 = new Student("Aleksandar", "Georgiev", 2);
            Student student3 = new Student("Aleksandar", "Georgiev", 3);
            Student student4 = new Student("Aleksandar", "Georgiev", 4);
            Student student5 = new Student("Aleksandar", "Georgiev", 5);
            Student student6 = new Student("Aleksandar", "Georgiev", 6);
            Student student7 = new Student("Aleksandar", "Georgiev", 7);
            Student student8 = new Student("Aleksandar", "Georgiev", 8);
            Student student9 = new Student("Aleksandar", "Georgiev", 9);
            Student student10 = new Student("Aleksandar", "Georgiev", 10);

            students.Add(student4);
            students.Add(student5);
            students.Add(student6);
            students.Add(student7);
            students.Add(student8);
            students.Add(student9);
            students.Add(student10);
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            students = students.StudentsGradeSort();    //Sorting students by grades

            foreach (Student student in students)
            {
                Console.WriteLine(student.Grade);
            }
            Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            Worker worker1 = new Worker("Aleksandar", "Borisov", 200, 8);
            Worker worker2 = new Worker("Aleksandar", "Borisov", 400, 8);
            Worker worker3 = new Worker("Aleksandar", "Borisov", 600, 8);
            Worker worker4 = new Worker("Aleksandar", "Borisov", 800, 8);
            Worker worker5 = new Worker("Aleksandar", "Borisov", 1000, 8);
            Worker worker6 = new Worker("Aleksandar", "Borisov", 1200, 8);
            Worker worker7 = new Worker("Aleksandar", "Borisov", 1400, 8);
            Worker worker8 = new Worker("Aleksandar", "Borisov", 1600, 8);
            Worker worker9 = new Worker("Aleksandar", "Borisov", 1800, 8);
            Worker worker10 = new Worker("Boris", "Borisov", 2000, 8);

            workers.Add(worker6);
            workers.Add(worker7);
            workers.Add(worker8);
            workers.Add(worker9);
            workers.Add(worker10);
            workers.Add(worker1);
            workers.Add(worker2);
            workers.Add(worker3);
            workers.Add(worker4);
            workers.Add(worker5);

            workers = workers.WorkersMoneyPerHour();    //Sorting workers by money per hour

            foreach (Worker worker in workers)
            {
                Console.WriteLine(worker.MoneyPerHour());
            }

            List<Human> humans = new List<Human>();
            
            humans.AddRange(students);
            humans.AddRange(workers);

            humans = humans.NameOrder();    //Sorting humans by first and last name

            foreach (Human human in humans)
            {
                Console.WriteLine("{0} {1}",human.FirstName, human.LastName);
            }
        }
    }
}
