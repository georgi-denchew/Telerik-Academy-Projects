using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Phonebook
{
    class Examples
    {
        static void Main(string[] args)
        {
            string filePath = "phones.txt";
            Phonebook phonebook = new Phonebook(filePath);

            // Three results expected
            phonebook.Find("Mimi");
            Console.WriteLine();

            //Three results expected
            phonebook.Find("Shmatkata");
            Console.WriteLine();

            // One result expected
            phonebook.Find("Shmatkata", "Plovdiv");
            Console.WriteLine();
            // One result expected
            phonebook.Find("Shmatkata", "Ruse");
            Console.WriteLine();
            // One result expected
            phonebook.Find("Shmatkata", "Pernik");
            Console.WriteLine();
            // One result expected
            phonebook.Find("Patkata");
            Console.WriteLine();
            // No entries expected
            phonebook.Find("Mimi", "burgas");
            Console.WriteLine();
            // No entries expected
            phonebook.Find("Mim");
            Console.WriteLine();
            // No entries expected
            phonebook.Find("imi");
            Console.WriteLine();
            // One result expected
            phonebook.Find("Mimi", "Burgas");
            Console.WriteLine();
        }
    }
}
