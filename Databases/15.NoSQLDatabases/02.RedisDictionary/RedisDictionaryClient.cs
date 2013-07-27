using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RedisDictionary
{
    class RedisDictionaryClient
    {
        private static char[] separators = new char[] { ' ' };

        static void Main(string[] args)
        {
            PrintIntroductionMessage();

            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                ReadInput(redisClient);
            }
        }

        private static void ReadInput(RedisClient redisClient)
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                string[] inputWords = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);


                string cmd = inputWords[0].ToLower().Trim();

                if (cmd == "add")
                {
                    AddWord(redisClient, inputWords[1], inputWords[2]);
                }
                else if (cmd == "translate")
                {
                    GetTranslation(redisClient, inputWords[1]);
                }
                else if (userInput.Trim().ToLower() == "list all words")
                {
                    GetAllWords(redisClient);
                }
                else if (cmd == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        private static void GetAllWords(RedisClient redisClient)
        {
            var result = redisClient.GetAllEntriesFromHash("dictionary");

            foreach (var pair in result)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }

        private static void GetTranslation(RedisClient redisClient, string word)
        {
            if (word == null || word == string.Empty)
            {
                Console.WriteLine("Invalid input.");
            }

            var result = redisClient.GetValueFromHash("dictionary", word);

            Console.WriteLine("{0} - {1}", word, result);
        }

        private static void AddWord(RedisClient redisClient, string word, string translation)
        {
            if (word == string.Empty || word == null ||
                translation == string.Empty || translation == null)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            bool isSet = redisClient.SetEntryInHashIfNotExists(
                "dictionary", word, string.Format("{0}; ", translation));
            
            if (!isSet)
            {
                string newTranslation = 
                    redisClient.GetValueFromHash("dictionary", word) + translation + "; ";

                redisClient.SetEntryInHash("dictionary", word, newTranslation);
            }

            Console.WriteLine("Translation to word \"{0}\" added successfully", word);
        }

        private static void PrintIntroductionMessage()
        {
            StringBuilder outputmessage = new StringBuilder();
            outputmessage.AppendLine("Welcome to the Redis Dictionary." +
                " Based on your needs please enter one of the following:");

            outputmessage.AppendLine("To add a new word to the dictionary: add <word> <translation>");
            outputmessage.AppendLine("To get all words and their translations: list all words");
            outputmessage.AppendLine("To get translation of given word: translate <word>");
            outputmessage.AppendLine("To exit the dictionary application: exit");
            outputmessage.AppendLine();
            outputmessage.AppendLine("NOTE: Duplicated entries are allowed since it is natural " +
                "that a word can have more than one translation. This mean that when you use " +
                " the \"translate\" command you will get all the translations of the requested word.");
            Console.WriteLine(outputmessage);
        }
    }
}
