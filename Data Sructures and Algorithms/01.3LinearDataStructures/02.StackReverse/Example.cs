namespace _02.StackReverse
{
    using System;
    using System.Collections.Generic;

    class Example
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by an empty line.");

            Stack<int> sequence = new Stack<int>();

            string input = string.Empty;
            int parsedNumber = 0;
            bool parseSuccessful = false;
            
            while (true)
            {
                input = Console.ReadLine();

                if (input == null || input == string.Empty)
                {
                    break;
                }

                parseSuccessful = int.TryParse(input, out parsedNumber);

                if (parseSuccessful)
                {
                    sequence.Push(parsedNumber);
                }
            }

            while (sequence.Count != 0)
            {
                Console.WriteLine(sequence.Pop());
            }
        }
    }
}
