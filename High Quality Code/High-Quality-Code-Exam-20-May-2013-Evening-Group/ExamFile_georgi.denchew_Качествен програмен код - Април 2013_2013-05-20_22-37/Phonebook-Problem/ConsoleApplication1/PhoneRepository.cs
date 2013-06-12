namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookRepository : IPhonebookRepository
    {
        private List<PhonebookEntry> entries;

        public PhonebookRepository()
        {
            this.entries = new List<PhonebookEntry>();
        }

        public int EntriesCount
        {
            get
            {
                return this.entries.Count;
            }
        }

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            var sameNameCount =
                from entry in this.entries
                where entry.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select entry;

            bool isNameNew;

            if (sameNameCount.Count() == 0)
            {
                PhonebookEntry entry = new PhonebookEntry(name);

                foreach (var number in numbers)
                {
                    entry.PhoneNumbers.Add(number);
                }

                this.entries.Add(entry);

                isNameNew = true;
            }
            else if (sameNameCount.Count() == 1)
            {
                PhonebookEntry existingEntry = sameNameCount.First();
                foreach (var number in numbers)
                {
                    existingEntry.PhoneNumbers.Add(number);
                }

                isNameNew = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + name);
                return false;
            }

            return isNameNew;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var list =
                from e in this.entries
                where e.PhoneNumbers.Contains(oldNumber)
                select e;

            int changedNumbersCount = 0;

            foreach (var entry in list)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                entry.PhoneNumbers.Add(newNumber);
                changedNumbersCount++;
            }

            return changedNumbersCount;
        }

        public PhonebookEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || (startIndex + count > this.entries.Count))
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.Sort();

            PhonebookEntry[] resultList = new PhonebookEntry[count];

            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhonebookEntry entry = this.entries[i];
                resultList[i - startIndex] = entry;
            }

            return resultList;
        }
    }
}
