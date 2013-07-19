namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Examples
    {
        static void Main(string[] args)
        {
            HashTable<string, int> testTable = new HashTable<string, int>();
            testTable.Add("one", 1);
            testTable.Add("two", 2);
            testTable.Add("three", 3);
            testTable.Add("four", 4);
            testTable.Add("five", 5);
            testTable.Add("six", 6);
            testTable.Add("seven", 7);
            testTable.Add("eight", 8);
            testTable.Add("nine", 9);
            testTable.Add("ten", 10);
            testTable.Add("eleven", 11);
            testTable.Add("twelve", 12);
            testTable.Add("thirteen", 13);
            testTable.Add("fourteen", 14);
            testTable.Add("fifteen", 15);
            testTable.Add("sixteen", 16);
            testTable.Add("seventeen", 17);
            testTable.Add("eighteen", 18);
            testTable.Add("nineteen", 19);
            testTable.Add("twenty", 20);
            testTable.Add("twenty one", 21);
            testTable.Add("twenty two", 22);
            testTable.Add("twenty three", 23);
            testTable.Add("twenty four", 24);

            testTable.Remove("one");

            // Check these variables values for examples
            Console.WriteLine("Indexed LinkedList in the HashTable:");
            Console.WriteLine();
            LinkedList<KeyValuePair<string, int>> indexedList = testTable[0];

            foreach (var item in indexedList)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }

            Console.WriteLine();

            Console.WriteLine("All keys in the HashTable:");
            Console.WriteLine();
            var keys = testTable.Keys;

            foreach (var key in keys)
            {
                Console.WriteLine("{0}", key);
            }

            Console.WriteLine();

            var foundElement = testTable.Find("ten");
            Console.WriteLine("Value found by key: {0}", foundElement);

            Console.WriteLine();
            Console.WriteLine("Count of the elements in the HashTable: {0}", testTable.Count);
            Console.WriteLine();

            Console.WriteLine(
                "All elements in the HashTable iterated with foreach loop {0}(element \"one\" is deleted):", Environment.NewLine);
            Console.WriteLine();

            foreach (var keyValuePair in testTable)
            {
                Console.WriteLine("{0} {1}", keyValuePair.Key, keyValuePair.Value);
            }

            testTable.Clear();
        }
    }
}
