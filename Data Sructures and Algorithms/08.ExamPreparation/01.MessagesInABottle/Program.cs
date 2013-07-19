namespace _01.MessagesInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static Dictionary<string, char> decoder = new Dictionary<string, char>();

        static void Main(string[] args)
        {
            string encodedMessage = Console.ReadLine();
            string chiper = Console.ReadLine();
            StringBuilder decodingNumber = new StringBuilder();
            
            char currentLetter = default(char);

            for (int i = 0; i < chiper.Length; i++)
            {
                if (char.IsLetter(chiper[i]))
                {
                    if (i > 0)
                    {
                        decoder.Add(decodingNumber.ToString(), currentLetter);
                        decodingNumber.Clear();
                    }
                        
                    currentLetter = chiper[i];
                }
                else
                {
                    decodingNumber.Append(chiper[i]);
                }
            }

            decoder.Add(decodingNumber.ToString(), currentLetter);

            SortedSet<string> answers = new SortedSet<string>();
            int currentIndex = 0;

            string currentAnswer = string.Empty;
            
            GenerateAnswers(encodedMessage, currentAnswer, answers);

            Console.WriteLine(answers.Count);

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
        
        private static void GenerateAnswers(string encodedMessage, string currentAnswer, SortedSet<string> answers)
        {
            if (encodedMessage.Length == 0)
            {
                answers.Add(currentAnswer.ToString());
                return;
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < encodedMessage.Length; i++)
            {
                builder.Append(encodedMessage[i]);
                string currentKey = builder.ToString();

                if (decoder.ContainsKey(currentKey))
                {
                    string newAnswer = currentAnswer + decoder[currentKey];

                    string newMessage = encodedMessage.Substring(currentKey.Length);

                    GenerateAnswers(newMessage, newAnswer, answers);
                }
            }
        }
    }
}
