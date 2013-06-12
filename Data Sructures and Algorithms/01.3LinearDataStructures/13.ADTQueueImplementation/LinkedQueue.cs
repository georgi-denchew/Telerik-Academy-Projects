namespace _13.ADTQueueImplementation
{
    using System;

    /// <summary>
    /// Initializes an instance of the <see cref="LinkedQueue"/>class.
    /// </summary>
    /// <typeparam name="T">Template data-type of the LinkedQueue</typeparam>
    public class LinkedQueue<T>
    {
        private QueueNode<T> firstItem;
        private QueueNode<T> lastItem;

        /// <summary>
        /// Adds an element of the Template data-type
        /// at the end of the LinkedQueue.
        /// </summary>
        /// <param name="value">Variable to be added
        /// at the end of the LinkedQueue.</param>
        public void Enqueue(T value)
        {
            QueueNode<T> nextItem = new QueueNode<T>();
            nextItem.Value = value;

            if (this.firstItem == null)
            {
                this.lastItem = nextItem;
                this.firstItem = this.lastItem;
            }
            else
            {
                this.lastItem.NextItem = nextItem;
                this.lastItem = this.lastItem.NextItem;
            }
        }

        /// <summary>
        /// Gets the first item of the LinkedQueue and
        /// deletes it from the queue.
        /// </summary>
        /// <returns>The first item of the LinkedQueue</returns>
        public T Dequeue()
        {
            if (this.firstItem == null)
            {
                throw new ArgumentException("The queue is empty");
            }

            T itemToReturn = this.firstItem.Value;
            this.firstItem = this.firstItem.NextItem;

            return itemToReturn;
        }
    }
}
