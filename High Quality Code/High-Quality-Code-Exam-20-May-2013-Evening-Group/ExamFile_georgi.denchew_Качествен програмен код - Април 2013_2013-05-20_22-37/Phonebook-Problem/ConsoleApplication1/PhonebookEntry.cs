namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;
        private string nameLowerCases;
        private SortedSet<string> phoneNumbers;

        public PhonebookEntry(string name)
        {
            if (name == null || name == string.Empty)
            {
                throw new ArgumentException(
                    "Entry name cannot be null or an empty string");
            }

            this.Name = name;
            this.PhoneNumbers = new SortedSet<string>();
        }

        public SortedSet<string> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            private set
            {
                this.phoneNumbers = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameLowerCases = value.ToLowerInvariant();
            }
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Clear();
            result.Append('[');

            result.Append(this.Name);

            bool colonAppended = false;

            foreach (var phone in this.PhoneNumbers)
            {
                if (!colonAppended)
                {
                    result.Append(": ");
                    colonAppended = true;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phone);
            }

            result.Append(']');
            return result.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameLowerCases.CompareTo(other.nameLowerCases);
        }
    }
}
