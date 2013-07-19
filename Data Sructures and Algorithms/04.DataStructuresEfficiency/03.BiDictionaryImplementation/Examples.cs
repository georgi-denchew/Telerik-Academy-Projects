namespace _03.BiDictionaryImplementation
{
    using System;
    using System.Linq;

    class Examples
    {
        static void Main(string[] args)
        {
            BiDictionary<string, char, int> test = new BiDictionary<string, char, int>();

            test.Add("first", 'A', 1);
            test.Add("second", 'B', 2);
            test.Add("third", 'C', 3);
            test.Add("fourth", 'D', 4);

            test.Add("first", 'A', 5);
            test.Add("second", 'D', 6);
            test.Add("third", 'F', 7);
            test.Add("fourth", 'E', 8);


            var firstKeySearch = test.FindElementsByFirstKey("second");

            foreach (var item in firstKeySearch)
            {
                Console.WriteLine("{0}, ", item);
            }

            Console.WriteLine();
            
            var secondKeySearch = test.FindElementsBySecondKey('A');

            foreach (var item in secondKeySearch)
            {
                Console.WriteLine("{0}, ", item);
            }
            Console.WriteLine();

            var bothKeySearch = test.FindElementsByBothKeys("third", 'F');

            foreach (var item in bothKeySearch)
            {
                Console.WriteLine("{0}, ", item);
            }

        }
    }
}
