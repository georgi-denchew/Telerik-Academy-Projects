using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentCourses
{
    public class Printer
    {
        private static char[] Separators = new char[] { '|' };
        private SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> coursesParticipants;

        public Printer(string file)
        {
            this.Input = new StreamReader(file);
            this.coursesParticipants = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            
            this.ParseInput();
        }

        public StreamReader Input { get; private set; }

        private void ParseInput()
        {
            using (this.Input)
            {
                string line = this.Input.ReadLine();

                while (line != null)
                {
                    string[] words = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

                    this.AddParticipant(words[0].Trim(), words[1].Trim(), words[2].Trim());

                    line = this.Input.ReadLine();
                }
            }
        }

        private void AddParticipant(string firstName, string lastName, string course)
        {
            if (!this.coursesParticipants.ContainsKey(course))
            {
                SortedSet<string> firstNames = new SortedSet<string>();
                firstNames.Add(firstName);

                SortedDictionary<string, SortedSet<string>> names = new SortedDictionary<string, SortedSet<string>>();
                names.Add(lastName, firstNames);

                this.coursesParticipants.Add(course, names);
            }
            else
            {
                if (!this.coursesParticipants[course].ContainsKey(lastName))
                {
                    SortedSet<string> firstNames = new SortedSet<string>();
                    firstNames.Add(firstName);

                    this.coursesParticipants[course].Add(lastName, firstNames);
                }
                else
                {
                    this.coursesParticipants[course][lastName].Add(firstName);
                }
            }
        }

        internal void PrintParticipants()
        {
            StringBuilder output = new StringBuilder();

            var courses = this.coursesParticipants.Keys;

            foreach (var course in courses)
            {
                output.Append(string.Format("{0}: ",course));

                var lastNames = this.coursesParticipants[course].Keys;

                foreach (var lastName in lastNames)
                {
                    var firstNames = this.coursesParticipants[course][lastName];

                    foreach (string firstName in firstNames)
                    {
                        output.Append(string.Format("{0} {1}, ", firstName, lastName));
                    }                    
                }

                output.Remove(output.Length - 2, 1);
                output.AppendLine();
            }

            Console.WriteLine(output.ToString());
        }
    }
}
