using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentCourses
{
    class Examples
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer("students.txt");


            // Note: Ordering: First by course, then by last name
            // and then by first name
            printer.PrintParticipants();
        }
    }
}
