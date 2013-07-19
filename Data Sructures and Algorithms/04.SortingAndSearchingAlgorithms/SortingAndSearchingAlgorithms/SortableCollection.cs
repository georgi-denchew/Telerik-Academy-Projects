namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            MergeSorter<T> sorter = new MergeSorter<T>();
            sorter.Sort(this.items);
            int leftIndex = 0;
            int rightIndex = this.items.Count - 1;

            while (leftIndex <= rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                
                if (this.items[middleIndex].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.items[middleIndex].CompareTo(item) == -1)
                {
                    leftIndex = middleIndex + 1;
                }
                else if (this.items[middleIndex].CompareTo(item) == 1)
                {
                    rightIndex = middleIndex - 1;
                }
            }

            return false;
        }

        /// <summary>
        /// Complexity of the shuffling algorithm is O(n)
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();

            for (int index = 0; index < this.items.Count; index++)
            {
                int randomIndex = index + rand.Next(0, this.items.Count - index);

                T temp = this.items[index];
                this.items[index] = this.items[randomIndex];
                this.items[randomIndex] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
