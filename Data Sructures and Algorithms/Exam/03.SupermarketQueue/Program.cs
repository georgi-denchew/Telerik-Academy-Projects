using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _03.SupermarketQueue
{
    class Program
    {
        static Supermarket supermarket = new Supermarket();
        static StringBuilder output = new StringBuilder();

        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();

                input.AppendLine(line);

                if (line == "End")
                {
                    break;
                }
            }

            string[] allLines = input.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in allLines)
            {
                string[] currentLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ParseInput(currentLine);
            }

            Console.WriteLine(supermarket.Output.ToString());
        }

        public static void ParseInput(string[] splitLine)
        {
            if (splitLine[0] == "Append")
            {
                supermarket.Append(splitLine[1]);
            }

            else if (splitLine[0] == "Insert")
            {
                supermarket.Insert(int.Parse(splitLine[1]), splitLine[2]);
            }

            else if (splitLine[0] == "Find")
            {
                supermarket.Find(splitLine[1]);
            }
            else if (splitLine[0] == "Serve")
            {
                supermarket.Serve(int.Parse(splitLine[1]));
            }
        }
    }

    public class Supermarket
    {
        public Supermarket()
        {
            this.Output = new StringBuilder();

            this.Deque = new Deque<string>();
        }


        public Deque<string> Deque { get; set; }

        public StringBuilder Output { get; set; }

        public void Append(string name)
        {
            this.Deque.AddToBack(name);
            this.Output.AppendLine("OK");
        }

        internal void Insert(int position, string name)
        {
            if (position > this.Deque.Count)
            {
                this.Output.AppendLine("Error");
                return;
            }
            else
            {
                this.Deque.Insert(position, name);
                this.Output.AppendLine("OK");
            }
        }

        internal void Find(string name)
        {
            var found = this.Deque.FindAll(x => x == name);
            this.Output.AppendLine(found.Count().ToString());
        }

        internal void Serve(int peopleCount)
        {
            if (peopleCount > this.Deque.Count)
            {
                this.Output.AppendLine("Error");
                return;
            }

            for (int i = 0; i < peopleCount; i++)
            {
                this.Output.Append(string.Format("{0} ", this.Deque.RemoveFromFront()));
            }

            this.Output.Length--;
            this.Output.Append(Environment.NewLine);
        }
    }
}