namespace _06.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Phonebook
    {
        private static char[] separator = {'|'};

        public Phonebook(string filePath)
        {
            this.Reader = new StreamReader(filePath);
            this.Entries = new Dictionary<string, List<string>>();

            this.FillPhonebook();
        }

        public StreamReader Reader { get; private set; }
        
        public Dictionary<string, List<string>> Entries { get; private set; }

        public void Find(string name)
        {
            // This check is made to make sure that a whole-word match is found,
            // and not just a part of a word. For example:
            // When we search for "Ivan" and get "Ivanov" instead.
            // The name may be at the beginning, where it will have a " " after it
            // or in the middle (the town is always last) where it will have
            // a " " infront of it and a " " after it.
            var selectedEntries = this.Entries.Where(x => (x.Key.StartsWith(name + " ")
                || x.Key.Contains(" " + name + " ")));

            if (selectedEntries.Count() == 0)
            {
                Console.WriteLine("No entry matches found.");
            }

            foreach (var entry in selectedEntries)
            {
                Console.WriteLine("{0} {1}", entry.Key, entry.Value);
            }
        }

        public void Find(string name, string town)
        {
            // Again making sure the town is a whole word
            // It's the last word of the input string so
            // it will always have a " " infront of it.
            var townMatches = this.Entries.Where(x => x.Key.EndsWith(" " + town));

            var selectedEntries = townMatches.Where(x => (x.Key.StartsWith(name + " ")
                || x.Key.Contains(" " + name + " ")));

            if (selectedEntries.Count() == 0)
            {
                Console.WriteLine("No entry matches found.");
            }

            foreach (var entry in selectedEntries)
            {
                Console.WriteLine("{0} {1}", entry.Key, entry.Value);
            }
        }

        private void FillPhonebook()
        {
            using(this.Reader)
            {
                string line = this.Reader.ReadLine();

                while (line != null)
                {                    
                    this.AddPhonebookEntry(line);

                    line = this.Reader.ReadLine();
                }
            }
        }

        private void AddPhonebookEntry(string line)
        {
            string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim();
            }
            parts[0] += " " + parts[1];

            this.Entries.Add(parts[0], parts[2]);
        }
    }
}
