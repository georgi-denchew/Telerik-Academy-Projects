using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MessageInABottle
{
    class Program
    {
        static List<KeyValuePair<char, string>> chiphers = new List<KeyValuePair<char, string>>();
        static string message;
        static List<string> solutions = new List<string>();

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            string chipher = Console.ReadLine();
            char key = '\0';
            StringBuilder value = new StringBuilder();


            for (int i = 0; i < chipher.Length; i++)
            {

                // faster than char.IsLetter
                if (chipher[i] >= 'A' && chipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        chiphers.Add(new KeyValuePair<char,string>(key, value.ToString()));
                        value.Clear();
                    }
                    key = chipher[i];

                }
                else
                {
                    value.Append(chipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                chiphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(0, new StringBuilder());
            Console.WriteLine(solutions.Count);

            solutions.Sort();
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }

        static int count = 0;

        static void Solve(int secretMessageIndex, StringBuilder sb)
        {
            foreach (var chipher in chiphers)
            {
                if (secretMessageIndex == message.Length)
                {
                    count++;
                    solutions.Add(sb.ToString());
                    return;
                }


                if (message.Substring(secretMessageIndex).StartsWith(chipher.Value))
                {
                    sb.Append(chipher.Key);
                    Solve(secretMessageIndex + chipher.Value.Length, sb);
                    sb.Length--;
                }
                //Solve();
            }
        }
    }
}
