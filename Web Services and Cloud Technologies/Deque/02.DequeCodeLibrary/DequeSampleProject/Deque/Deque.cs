using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{

/// <summary>
/// A double-ended queue class. Supports insertion and removal at both ends.
/// Combines the functionality of both queue and stack data structures.
/// </summary>
/// <typeparam name="T">Specifies the element type of the deque.</typeparam>
    public class Deque<T> : IDeque<T>
    {
        private LinkedList<T> listItems;

/// <summary>
/// Initializes a new instance of the <see cref="Deque{T}"/> class.
/// </summary>
        public Deque()
        {
            this.listItems = new LinkedList<T>();
        }

/// <summary>
/// Gets the number of elements actually contained in the <see cref="Deque{T}"/> instance.
/// </summary>
/// <value>
/// The count of contained elements.
/// </value>
        public int Count { 
            get
            {
                return this.listItems.Count;
            }
        }

/// <summary>
/// Adds a new element at the start of the <see cref="Deque{T}"/> instance.
/// </summary>
/// <param name="element">The element to be added.</param>
        public void PushFirst(T element)
        {
            this.listItems.AddFirst(element);
        }

/// <summary>
/// Adds a new element at the end of the <see cref="Deque{T}"/> instance.
/// </summary>
/// <param name="element">The element to be added.</param>
        public void PushLast(T element)
        {
            this.listItems.AddLast(element);
        }

/// <summary>
/// Gets the first element of the <see cref="Deque{T}"/> and removes it from the collection.
/// </summary>
/// <returns>The first element of the <see cref="Deque{T}"/></returns>
        public T PopFirst()
        {
            var node = this.listItems.First;
            T value = node.Value;

            this.listItems.RemoveFirst();

            return value;
        }

/// <summary>
/// Gets the last element of the <see cref="Deque{T}"/> and removes it from the collection.
/// </summary>
/// <returns>The last element of the <see cref="Deque{T}"/></returns>
        public T PopLast()
        {
            var node = this.listItems.Last;
            T value = node.Value;

            this.listItems.RemoveLast();

            return value;
        }

/// <summary>
/// Gets the first element of the <see cref="Deque{T}"/>.
/// </summary>
/// <returns>The first element of the <see cref="Deque{T}"/></returns>
        public T PeekFirst()
        {
            return this.listItems.First.Value;
        }

/// <summary>
/// Gets the last element of the <see cref="Deque{T}"/>.
/// </summary>
/// <returns>The last element of the <see cref="Deque{T}"/></returns>
        public T PeekLast()
        {
            return this.listItems.Last.Value;
        }

/// <summary>
/// Removes all nodes from the <see cref="Deque{T}"/>
/// </summary>
        public void Clear()
        {
            this.listItems.Clear();
        }

        /// <summary>
        /// Determines whether a value is in the <see cref="Deque{T}"/>
        /// </summary>
        /// <param name="element">Value to locate in the <see cref="Deque{T}"/>. The value can be null for reference types</param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            return this.listItems.Contains(element);
        }
    }

    public interface IDeque<T>
    {
        int Count { get;}
        void PushFirst(T element);
        void PushLast(T element);
        T PopFirst();
        T PopLast();
        T PeekFirst();
        T PeekLast();
        void Clear();
        bool Contains(T element);
    }
}
