using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.NullValuesToIntegerAndDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int? first = null;
            double? second = null;
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(first + 2);
            Console.WriteLine(second + 5);
            Console.WriteLine(first + null);
        }
    }
}
