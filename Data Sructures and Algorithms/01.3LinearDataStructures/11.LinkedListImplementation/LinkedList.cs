namespace _11.LinkedListImplementation
{
    using System;
    
    public class LinkedList<T>
    {
        /// <summary>
        /// In this implementation after adding some items
        /// the first item actually becomes last item.
        /// </summary>     
        private ListItem<T> firstItem;

        /// <summary>
        /// Add an element of type T at the beginning of
        /// the linked list.
        /// </summary>
        /// <param name="value">Value of the item to be added</param>
        public void Add(T value)
        {
            ListItem<T> nextItem = new ListItem<T>();
            nextItem.Value = value;
            nextItem.NextItem = this.firstItem;
            this.firstItem = nextItem;
        }

        /// <summary>
        /// Prints on the console all present elements of given list.
        /// </summary>
        public void PrintAllElements()
        {
            ListItem<T> currentItem = this.firstItem;

            while (currentItem != null)
            {
                Console.WriteLine(currentItem.Value);
                currentItem = currentItem.NextItem;
            }
        }
    }
}
