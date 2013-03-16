using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    //We are given a school. In the school there are classes of students. 
    //Each class has a set of teachers. Each teacher teaches a set
    //of disciplines. Students have name and unique class number. 
    //Classes have unique text identifier. Teachers have name. 
    //Disciplines have name, number of lectures and number of exercises.
    //Both teachers and students are people. Students, classes, teachers 
    //and disciplines could have optional comments (free text block).
	//Your task is to identify the classes (in terms of  OOP) and their 
    //attributes and operations, encapsulate their fields, define the 
    //class hierarchy and create a class diagram with Visual Studio.

    class _Examples
    {
        static void Main(string[] args)
        {

            Student pesho = new Student("Pesho", 1);
            pesho.AddComment("bad boy");
            Console.WriteLine(pesho.Name);
            Console.WriteLine(pesho.ClassNumber);
            Console.WriteLine(pesho.Comments);
            Console.WriteLine();

            Discipline history = new Discipline("History",10,15);
            history.AddComment("booring");
            Console.WriteLine(history.Name);
            Console.WriteLine(history.LecturesNumber);
            Console.WriteLine(history.ExercisesNumber);
            Console.WriteLine(history.Comments);
            Console.WriteLine();

            List<Discipline> peshevDisciplines = new List<Discipline>();
            Discipline geography = new Discipline("Geography", 5, 6);
            peshevDisciplines.Add(geography);
            peshevDisciplines.Add(history);
            
            Teacher daskalPeshev = new Teacher("Peshev", peshevDisciplines);
            Console.WriteLine("Teacher {0}'s disciplines:", daskalPeshev.Name);
            
            foreach (Discipline discipline in daskalPeshev.Disciplines)
            {

                Console.WriteLine(discipline.Name);
            }
            Console.WriteLine();

            List<Teacher> firstClassTeachers = new List<Teacher>();
            firstClassTeachers.Add(daskalPeshev);
            firstClassTeachers.Add(new Teacher("Daskalov", peshevDisciplines));

            List<Student> firstClassStudents = new List<Student>();
            firstClassStudents.Add(pesho);
            firstClassStudents.Add(new Student("mariika", 2));

            Class first = new Class("1A", firstClassTeachers, firstClassStudents);
            Console.WriteLine("{0} class teachers:", first.Identifier);

            foreach (Teacher teacher in firstClassTeachers)
            {
                Console.WriteLine(teacher.Name);
            }
            Console.WriteLine();
            Console.WriteLine("{0} class students:", first.Identifier);
            foreach (Student student in firstClassStudents)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();

            Class second = new Class("2B", firstClassTeachers, firstClassStudents);
            List<Class> classes = new List<Class>();
            classes.Add(first);
            classes.Add(second);

            School daskalo = new School("Frenskata gimnaziq", classes);
            Console.WriteLine(daskalo.Name);

            foreach (Class clas in daskalo.Classes)
            {
                Console.WriteLine(clas.Identifier);
            }
        }
    }
}
