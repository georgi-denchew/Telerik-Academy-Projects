using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.MongoDBDictionary
{
    class DictionaryClient
    {
        private static char[] separators = new char[] { ' ' };
        List<Word> words = null;

        static void Main(string[] args)
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var dictionaryDb = mongoServer.GetDatabase("Dictionary");
            var dictionary = dictionaryDb.GetCollection("words");            

            PrintIntroductionMessage();

            ReadInput(dictionary);
        }

        private static void ReadInput(MongoCollection<BsonDocument> dictionary)
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                string[] inputWords = userInput.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string cmd = inputWords[0].ToLower().Trim();

                if (cmd == "add")
                {
                    AddWord(dictionary, inputWords[1], inputWords[2]);
                }
                else if (cmd == "translate")
                {
                    GetTranslation(dictionary, inputWords[1]);
                }
                else if (userInput.Trim().ToLower() == "list all words")
                {
                    GetAllWords(dictionary);
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

        private static void GetAllWords(MongoCollection<BsonDocument> dictionary)
        {
            var result = dictionary.FindAll();

            foreach (var pair in result)
            {
                string name = pair["Name"].AsString;
                string translation = pair["Translation"].AsString;

                Console.WriteLine("{0} - {1}", name , translation);
            }
        }

        private static void GetTranslation(MongoCollection<BsonDocument> dictionary, string word)
        {
            var query = Query.EQ("Name", word);
            var result = dictionary.FindAs<Word>(query);

            foreach (var pair in result)
            {
                Console.WriteLine("{0} - {1}", pair.Name, pair.Translation);
            }
        }

        private static void AddWord(MongoCollection<BsonDocument> dictionary, string word, string translation)
        {
            if (word == null || word == string.Empty ||
                translation == null || translation == string.Empty)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Word wordToInsert = new Word(word, translation);
            dictionary.Insert(wordToInsert);

            Console.WriteLine("Word \"{0}\" added successfully", word);
        }


        private static void PrintIntroductionMessage()
        {
            StringBuilder outputmessage = new StringBuilder();
            outputmessage.AppendLine("Welcome to the MongoDB Dictionary." + 
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
