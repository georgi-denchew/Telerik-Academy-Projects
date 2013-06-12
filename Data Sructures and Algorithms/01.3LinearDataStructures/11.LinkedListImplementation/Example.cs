using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    class Example
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(1);            
            list.Add(2);
            list.Add(3);

            list.PrintAllElements();
        }
    }
}
