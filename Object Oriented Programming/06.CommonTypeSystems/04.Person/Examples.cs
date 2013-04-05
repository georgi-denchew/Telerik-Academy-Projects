using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Person
{
    //TASK 04: Create a class Person with two fields – name and age.
    //Age can be left unspecified (may contain null value. 
    //Override ToString() to display the information of a person 
    //and if age is not specified – to say so. Write a program to
    //test this functionality.

    class Examples
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("pesho", 3); //Age is specified
            Console.WriteLine(pesho);

            Person gosho = new Person("gosho"); //Age is unspecified
            Console.WriteLine(gosho);
        }
    }
}
