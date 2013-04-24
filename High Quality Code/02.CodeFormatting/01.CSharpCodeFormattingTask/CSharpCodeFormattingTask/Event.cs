using System;
using System.Text;

namespace CSharpCodeFormattingTask
{
    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public DateTime Date 
        {
            get
            {
                return this.date;
            }

            private set
            {
                this.date = value;
            }
        }

        public string Title 
        { 
            get
            {
                return this.title;
            }

            private set
            {
                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                this.location = value;
            }
        }

        public int CompareTo(object obj)
        {
            Event otherEvent = obj as Event;

            if (this == null)
            {
                if (otherEvent == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (otherEvent == null)
            {
                return 1;
            }

            int dateComparer = this.date.CompareTo(otherEvent.date);
            int titleComparer = this.title.CompareTo(otherEvent.title);
            int locationComparer = this.location.CompareTo(otherEvent.location);

            if (dateComparer == 0)
            {
                if (titleComparer == 0)
                {
                    return locationComparer;
                }
                else
                {
                    return titleComparer;
                }
            }
            else
            {
                return dateComparer;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                result.Append(" | " + this.location);
            }

            return result.ToString();
        }
    }
}
