namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ApplicationExecutor
    {
        private const string CountryCode = "+359";

        private static IPhonebookRepository repository = new PhonebookRepository();

        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            Run();

            Console.Write(output);
        }

        private static void Run()
        {
            string inputString = string.Empty;

            while (true)
            {
                inputString = Console.ReadLine();

                if (inputString == "End")
                {
                    break;
                }

                int openingBracketIndex = inputString.IndexOf('(');

                bool validInputStringEnding = inputString.EndsWith(")");

                if (openingBracketIndex == -1 || !validInputStringEnding)
                {
                    throw new FormatException(
                        "The command input string is not in the correct format");
                }

                int parametersStartIndex = openingBracketIndex + 1;
                int parametersEndIndex = inputString.Length - openingBracketIndex - 2;

                string parametersString = inputString.Substring(
                    parametersStartIndex, parametersEndIndex);

                string[] parameters = parametersString.Split(',');

                for (int j = 0; j < parameters.Length; j++)
                {
                    parameters[j] = parameters[j].Trim();
                }

                string command = inputString.Substring(0, openingBracketIndex);

                ParseCommands(command, parameters);
            }
        }

        private static void ParseCommands(string command, string[] parameters)
        {
            if (command.StartsWith("AddPhone") && (parameters.Length >= 2))
            {
                ExecuteCommand("AddPhone", parameters);
            }
            else if (command.StartsWith("ChangePhone") && (parameters.Length == 2))
            {
                ExecuteCommand("ChangePhone", parameters);
            }
            else if (command.StartsWith("List") && (parameters.Length == 2))
            {
                ExecuteCommand("List", parameters);
            }
            else
            {
                throw new FormatException(string.Format(
                    "The command {0} is invalid", command));
            }
        }

        private static void ExecuteCommand(string cmd, string[] parameters)
        {
            if (cmd == "AddPhone")
            {
                string name = parameters[0];

                var phoneNumbers = parameters.Skip(1).ToList();

                for (int i = 0; i < phoneNumbers.Count; i++)
                {
                    phoneNumbers[i] = ConvertNumber(phoneNumbers[i]);
                }

                bool nameExists = repository.AddPhone(name, phoneNumbers);

                if (nameExists)
                {
                    AppendToOutput("Phone entry created");
                }
                else
                {
                    AppendToOutput("Phone entry merged");
                }
            }
            else if (cmd == "ChangePhone")
            {
                int changedNumbersCount = repository.ChangePhone(
                    ConvertNumber(parameters[0]), ConvertNumber(parameters[1]));

                AppendToOutput(changedNumbersCount + " numbers changed");
            }
            else if (cmd == "List")
            {
                try
                {
                    IEnumerable<PhonebookEntry> entries = repository.ListEntries(
                        int.Parse(parameters[0]), int.Parse(parameters[1]));

                    foreach (var entry in entries)
                    {
                        AppendToOutput(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    AppendToOutput("Invalid range");
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid command {0}", cmd));
            }
        }

        // This is a bottleneck - the whole operation was repeated 3 times
        // - absolutely unnecessar; and the foreach loop is slow
        private static string ConvertNumber(string number)
        {
            StringBuilder convertedNumber = new StringBuilder();

            for (int i = 0; i <= output.Length; i++)
            {
                convertedNumber.Clear();

                for (int j = 0; j < number.Length; j++)
                {
                    if (char.IsDigit(number[j]) || number[j] == '+')
                    {
                        convertedNumber.Append(number[j]);
                    }
                }

                if (convertedNumber.Length >= 2 && convertedNumber[0] == '0' && convertedNumber[1] == '0')
                {
                    convertedNumber.Remove(0, 1);
                    convertedNumber[0] = '+';
                }

                while (convertedNumber.Length > 0 && convertedNumber[0] == '0')
                {
                    convertedNumber.Remove(0, 1);
                }

                if (convertedNumber.Length > 0 && convertedNumber[0] != '+')
                {
                    convertedNumber.Insert(0, CountryCode);
                }
            }

            return convertedNumber.ToString();
        }

        private static void AppendToOutput(string text)
        {
            output.AppendLine(text);
        }
    }   
}