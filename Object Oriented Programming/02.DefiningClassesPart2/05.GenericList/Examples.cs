using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericList
{
    //TASK 05: Write a generic class GenericList<T> that keeps a list 
    //of elements of some parametric type T.
    //!!!!Keep the elements of the list in an array with fixed capacity 
    //!!!!which is given as parameter in the class constructor. 
    //Implement methods for adding element, accessing element by index,
    //removing element by index, inserting element at given position,
    //clearing the list, finding element by its value and ToString().
    //Check all input parameters to avoid accessing elements at invalid positions.

    //TASK 06:Implement auto-grow functionality: when the internal array is full,
    //create a new array of double size and move all elements to it.

    //TASK 07:Create generic methods Min<T>() and Max<T>() for finding 
    //the minimal and maximal element in the  GenericList<T>. 
    //You may need to add a generic constraints for the type T.

    class Examples
    {
        static void Main(string[] args)
        {
            GenericList<int> numbersList = new GenericList<int>(3);
            numbersList.Add(1);
            numbersList.Add(2);
            numbersList.Add(0);
            numbersList.Add(4);

            Console.WriteLine(numbersList[1]);
            Console.WriteLine();

            Console.WriteLine(numbersList.FindIndexOf(1));
            Console.WriteLine();

            numbersList.Insert(1, 6);
            Console.WriteLine(numbersList[1]);
            Console.WriteLine();

            Console.WriteLine(numbersList.ToString()); // before removal
            Console.WriteLine();

            numbersList.Remove(2);

            Console.WriteLine(numbersList.ToString()); // after removal
            Console.WriteLine();


            Console.WriteLine(numbersList.Min());
            Console.WriteLine();
            Console.WriteLine(numbersList.Max());
            Console.WriteLine();

            numbersList.Clear();
            Console.WriteLine(numbersList.ToString());

        }
    }
}
