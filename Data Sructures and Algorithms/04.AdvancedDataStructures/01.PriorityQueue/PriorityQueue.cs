namespace _01.PriorityQueue
{
    using System;
    using System.Linq;

    public class PriorityQueue<T>
        where T : IComparable
    {
        private readonly BinaryHeap<T> binaryHeap;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue<T>"/> class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public PriorityQueue()
        {
            this.binaryHeap = new BinaryHeap<T>();
        }

        /// <summary>
        /// Gets the number of elements in the 
        /// <see cref="PriorityQueue<T>"/> instance.
        /// </summary>
        public int Size
        {
            get
            {
                return this.binaryHeap.Count;
            }
        }

        /// <returns>
        /// Returns the element
        /// with the highest priority.
        /// </returns>
        public T Top()
        {
            return this.binaryHeap.PeekRoot();
        }

        /// <summary>
        /// Removes the element with the highest
        /// priority from the queue and returns it.
        /// </summary>
        /// <returns>
        /// Returns the element with the highest priority.
        /// </returns>
        public T Pop()
        {
            return this.binaryHeap.PopRoot();
        }

        /// <summary>
        /// Inserts a new element in the given
        /// <see cref="PriorityQueue"/> instance.
        /// </summary>
        /// <param name="item">
        /// Element to be inserted.
        /// </param>
        public void Push(T item)
        {
            this.binaryHeap.Insert(item);
        }
    }
}
