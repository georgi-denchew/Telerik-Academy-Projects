using System;
using System.Text;

namespace CSharpCodeFormattingTask
{
    public static class Messages
    {
        private static readonly StringBuilder output = new StringBuilder();

        public static string Output
        {
            get
            {
                return output.ToString(); 
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added");
            output.Append(Environment.NewLine);

        }

        public static void EventDeleted(int eventsCount)
        {
            if (eventsCount == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted", eventsCount);
                output.Append(Environment.NewLine);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found");
            output.Append(Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint);
                output.Append(Environment.NewLine);
            }
        }
    }
}
