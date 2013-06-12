namespace _12.ADTStackImplementation
{
    using System;

    /// <summary>
    /// Initializes an instance of the <see cref="Stack"/> class.
    /// </summary>
    /// <typeparam name="T">Template data-type of the stack.</typeparam>
    class Stack<T>
    {
        private int capacity = 2;

        private int index = -1;

        private T[] elements;

        public Stack()
        {
            this.Elements = new T[this.Capacity];
        }

        public T[] Elements
        {
            get 
            { 
                return this.elements; 
            }

            set 
            { 
                this.elements = value; 
            }
        }

        public int Index
        {
            get 
            { 
                return this.index; 
            }

            set 
            {
                this.index = value; 
            }
        }

        public int Capacity
        {
            get 
            { 
                return this.capacity; 
            }
            
            set 
            { 
                this.capacity = value; 
            }
        }

        /// <summary>
        /// Adds an element at the top of the stack.
        /// </summary>
        /// <param name="element">Value of the element to be added.</param>
        public void Push(T element)
        {
            this.Index++;

            if (this.Index == this.Capacity)
            {
                this.IncreaseCapacity();
            }

            this.Elements[this.Index] = element;
        }

        /// <summary>
        /// Returns an element of the stack at given position.
        /// </summary>
        /// <param name="index">The position of the returned element</param>
        public T Peek(int index)
        {
            return this.Elements[index];
        }


        /// <summary>
        /// Removes and returns the element at the top of the stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T elementToReturn = this.Elements[this.Index];

            this.CopyTemporaryElements();

            this.Index--;

            return elementToReturn;
        }

        private void IncreaseCapacity()
        {
            this.Capacity = this.Capacity * 2;

            this.CopyTemporaryElements();
        }

        private void CopyTemporaryElements()
        {
            T[] temporaryElements = this.Elements;

            this.Elements = new T[this.Capacity];

            Array.Copy(temporaryElements, this.Elements, this.Index);
        }
    }
}
