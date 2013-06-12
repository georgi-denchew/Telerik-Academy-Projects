using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FirstFiftyMembers
{
    class Example
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter starting number for the sequence");
            
            Queue<int> sequence = new Queue<int>();
            int firstMember = int.Parse(Console.ReadLine());

            CreateSequence(firstMember, sequence);

            foreach (var item in sequence)
            {
                Console.Write("{0} ", item);
            }
        }

        public static void CreateSequence(int firstMember, Queue<int> sequence)
        {
            sequence.Enqueue(firstMember);

            int nextNumberIndex = 0;

            while (sequence.Count < 50)
            {
                sequence.Enqueue(firstMember + 1);
                sequence.Enqueue(2 * firstMember + 1);
                sequence.Enqueue(firstMember + 2);

                nextNumberIndex++;
                firstMember = sequence.ElementAt(nextNumberIndex);
            }
        }
    }
}
