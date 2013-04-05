using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Student
{
    //TASK 01: Define a class Student, which contains data about
    //a student – first, middle and last name, SSN, permanent 
    //address, mobile phone e-mail, course, specialty, university,
    //faculty. Use an enumeration for the specialties, 
    //universities and faculties. Override the standard methods,
    //inherited by  System.Object: Equals(), ToString(), 
    //GetHashCode() and operators == and !=.

    //TASK 02: Add implementations of the ICloneable interface. 
    //The Clone() method should deeply copy all object's fields 
    //into a new object of type Student.

    //TASK 03:Implement the  IComparable<Student> interface to 
    //compare students by names (as first criteria, in lexicographic 
    //order) and by social security number (as second criteria, in 
    //increasing order).




    class Examples
    {
        static void Main()
        {
            Student ivancho = new Student("Ivan", "Ivanchov", "Ivanchev", "123-456-7899", "Tuk-Tam str. No2", 0899876543, 
                "ivancho@gmail.com", 2, Universities.SofiaUniversity, Faculties.Law, Specialties.Lawyer);
            
            Student haivancho = new Student("Ivan", "Ivanchov", "Ivanchev", "123-456-7899", "Tuk-Tam str. No2", 0899876543,
                "ivancho@gmail.com", 2, Universities.SofiaUniversity, Faculties.Law, Specialties.Lawyer);

            Student differentIvancho = new Student("Choban", "Ivanchov", "Ivanchev", "123-456-0000", "Tuk-Tam str. No2", 0899876543, 
                "ivancho@gmail.com", 2, Universities.SofiaUniversity, Faculties.Law, Specialties.Lawyer); //Used for TASK3

            Student clonedIvancho = ivancho.Clone(); //TASK 02
            
            //Console.WriteLine(ivancho.Equals(haivancho)); //TASK 01 - uncomment to test

            //Console.WriteLine(ivancho); //TASK 01 - uncomment to test

            //Console.WriteLine(ivancho == haivancho); //TASK 01 - uncomment to test

            //Console.WriteLine(ivancho != differentIvancho); //TASK 02 - uncomment to test

            //Console.WriteLine(clonedIvancho); //TASK 02 - uncomment to test

            //Console.WriteLine(ivancho.CompareTo(differentIvancho)); //TASK 03 - uncomment to test
        }
    }
}
