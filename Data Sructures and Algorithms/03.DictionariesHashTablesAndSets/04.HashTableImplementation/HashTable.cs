namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Holds <see cref="KeyVauePair"/> elements in array of LinkedLists.
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="T">Value</typeparam>
    public class HashTable<K, T> : IEnumerator<KeyValuePair<K, T>>, IEnumerable<KeyValuePair<K, T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] array;
        private int count;
        private int arrayElementIndex;
        private int listElementIndex;

        /// <summary>
        /// Initializes a new instance of <see cref="HashTable"/> class.
        /// </summary>
        public HashTable()
        {
            this.array = new LinkedList<KeyValuePair<K, T>>[16];
            this.count = 0;
            this.arrayElementIndex = 0;
            this.listElementIndex = 0;
            this.Keys = new HashSet<K>();
        }

        /// <summary>
        /// Gets all keys in the HashTable
        /// </summary>
        public ICollection<K> Keys { get; private set; }

        /// <summary>
        /// Gets the count of KeyValuePairs in the HashTable
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        KeyValuePair<K, T> IEnumerator<KeyValuePair<K, T>>.Current
        {
            get
            {
                int currentListIndex = 0;
                KeyValuePair<K, T> result = new KeyValuePair<K, T>();

                foreach (var keyValuePair in this.array[this.arrayElementIndex])
                {
                    if (this.listElementIndex - 1 == currentListIndex)
                    {
                        result = keyValuePair;
                        return result;
                    }

                    currentListIndex++;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a LinkedList with KeyValuePair elements
        /// from the HashTable.
        /// </summary>
        /// <remarks>
        /// Does not get a single KeyValuePair element.
        /// The result could be a null value since 
        /// not all LinkedList items are neccessarily initialized.
        /// </remarks>
        public LinkedList<KeyValuePair<K, T>> this[int index]
        {
            get
            {
                return this.array[index];
            }

            set
            {
                this.array[index] = value;
            }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        public bool MoveNext()
        {
            // If the iteration in the current LinkedList element of
            // the array is completed we advance to the next LinkedList
            // and reset the list element indexer;
            if (this.array[this.arrayElementIndex] == null ||
                this.listElementIndex == this.array[this.arrayElementIndex].Count)
            {
                this.arrayElementIndex++;
                this.listElementIndex = 0;
            }

            // Since there might be arrays who's LinkedLists are not
            // created (because of the hash function) a check is made
            // and if the current LinkedList is null or empty
            // (for example all it's elements were deleted)
            // we move to the next one
            while (this.array[this.arrayElementIndex] == null ||
                this.array[this.arrayElementIndex].Count == 0)
            {
                this.arrayElementIndex++;

                // If the index is larger than the array lenght
                // there are no more elements
                if (this.arrayElementIndex >= this.array.Length)
                {
                    this.Reset();
                    return false;
                }
            }

            int currentListCount = this.array[this.arrayElementIndex].Count;

            // This loop updates the current position in the given LinkedList
            for (int i = 0; i < currentListCount; i++)
            {
                // Checks if the program has went through all
                // list elements
                if (this.listElementIndex == currentListCount)
                {
                    this.listElementIndex = 0;
                    return false;
                }

                this.listElementIndex++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element
        //  in the collection.
        /// </summary>
        public void Reset()
        {
            this.arrayElementIndex = 0;
        }

        /// <summary>
        /// Deletes all elements in the current HashTable.
        /// </summary>
        public void Clear()
        {
            this.array = new LinkedList<KeyValuePair<K, T>>[16];
            this.Count = 0;
        }

        /// <summary>
        /// Adds a new element in the HashTable
        /// </summary>
        /// <param name="key">Element key</param>
        /// <param name="value">Element value</param>
        /// <remarks>
        /// Duplicates are not allowed.
        /// </remarks>
        public void Add(K key, T value)
        {
            int position = this.GetArrayPosition(key);
            LinkedList<KeyValuePair<K, T>> currentList = this.GetLinkedList(position);
            KeyValuePair<K, T> currentItem = new KeyValuePair<K, T>(key, value);

            // If an element with the given key does 
            //not exist the variable will be initialized
            //with it's default values
            var existing = currentList.FirstOrDefault(x => (object)x.Key == (object)key);

            if (existing.Key == null || (existing.Key is IComparable))
            {
                this.Count++;
                currentList.AddLast(currentItem);
                this.Keys.Add(key);
            }
            
            else
            {
                throw new InvalidOperationException(string.Format(
                    "An element with the key \"{0}\" already exists in the current intance of the HashTable class",
                    (object)key.ToString()));
            }
        }

        /// <summary>
        /// Removes an element from the HashTable by it's key
        /// </summary>
        /// <param name="key">Key of the element to be removed</param>
        public void Remove(K key)
        {
            int position = this.GetArrayPosition(key);
            LinkedList<KeyValuePair<K, T>> currentList = this.GetLinkedList(position);

            KeyValuePair<K, T> itemToRemove = currentList.First(
                 x => ((object)x.Key as IComparable).CompareTo((object)key) == 0);

            if ((object)itemToRemove.Key != null)
            {
                this.Count--;
                currentList.Remove(itemToRemove);
                this.Keys.Remove(key);
            }
        }
        
        /// <summary>
        /// Finds value of the element with given key.
        /// </summary>
        /// <param name="key">Key of the element</param>
        /// <returns>Value ot the element with the given key.</returns>
        public T Find(K key)
        {
            int position = this.GetArrayPosition(key);
            LinkedList<KeyValuePair<K, T>> currentList = this.GetLinkedList(position);

            KeyValuePair<K, T> foundItem = currentList.FirstOrDefault(
                x => ((object)x.Key as IComparable).CompareTo((object)key) == 0);
            
            bool foundMatch = ((object)foundItem.Key as IComparable)
                .CompareTo((object)key) != 0;
            
            if (foundMatch)
            {
                return default(T);
            }
            else
            {
                return foundItem.Value;
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<K, T>>)this;
        }

        // I'm not sure what this method does.
        // I guess it has something to do with the garbage collector
        // I saw the implementation from msdn: http://msdn.microsoft.com/en-us/library/ms244737(v=vs.110).aspx
        // but I couldn't understand what the class "AnotherResource" should be, that's why I didn't fully
        // implement the method 
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        // This method does not need to implemented 
        // for the purpouse ot the current task
        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }

        // This method does not need to implemented 
        // for the purpouse ot the current task
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the LinkedList at a given position.
        /// </summary>
        private LinkedList<KeyValuePair<K, T>> GetLinkedList(int position)
        {
            if (this.array[position] == null)
            {
                if (this.Count >= 3 * this.array.Length / 4)
                {
                    this.Count = 0;
                    this.EnlargeArray();
                }
                this.array[position] = new LinkedList<KeyValuePair<K, T>>();
            }

            return this.array[position];
        }

        /// <summary>
        /// Doubles the array's length if it has reached 3/4 of it's capacity
        /// </summary>
        private void EnlargeArray()
        {
            LinkedList<KeyValuePair<K, T>>[] tempArray = this.array;
            this.array = new LinkedList<KeyValuePair<K, T>>[this.array.Length * 2];

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] != null)
                {
                    foreach (var item in tempArray[i])
                    {
                        this.Add(item.Key, item.Value);
                    }
                }
            }
        }

        // Hash function
        private int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % this.array.Length;
            return Math.Abs(position);
        }
    }
}
