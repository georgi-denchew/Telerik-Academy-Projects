using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IEnumerableExtensions
{
    //Implement a set of extension methods for IEnumerable<T>
    //that implement the following group functions: sum, product,
    //min, max, average.

    class Examples
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> {1, 2, 3, 4, 5};
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Product());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Average());
        }
    }
}
