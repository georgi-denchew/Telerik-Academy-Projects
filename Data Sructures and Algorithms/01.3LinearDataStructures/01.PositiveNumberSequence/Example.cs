namespace _01.PositiveNumberSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Example
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Enter positive numbers, each on a new line.{0}Enter an empty line to end the sequence.",
                Environment.NewLine);

            List<int> sequence = new List<int>();

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

                try
                {
                    if (!parseSuccessful || parsedNumber <= 0)
                    {
                        throw new FormatException(string.Format(
                            "The number you entered ({0}) is invalid or non-positive",
                            input));
                    }

                    sequence.Add(parsedNumber);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            if (sequence.Count > 0)
            {
                double sum = 0;

                for (int i = 0; i < sequence.Count; i++)
                {
                    sum += sequence[i];
                }

                double average = sum / sequence.Count;
                Console.WriteLine("The sum is {0}.{1}The average value is {2}.",
                    sum,
                    Environment.NewLine,
                    average);
            }
        }
    }
}
