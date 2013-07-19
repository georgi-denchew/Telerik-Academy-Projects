namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivotIndex = (leftIndex + rightIndex) / 2;

                int newPivotIndex = this.Partition(collection, leftIndex, rightIndex, pivotIndex);

                Quicksort(collection, leftIndex, newPivotIndex - 1);

                Quicksort(collection, newPivotIndex + 1, rightIndex);
            }
        }

        private int Partition(IList<T> collection, int leftIndex, int rightIndex, int pivotIndex)
        {
            T pivotValue = collection[pivotIndex];

            this.Swap(collection, pivotIndex, rightIndex);
            int storeIndex = leftIndex;

            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (collection[i].CompareTo(pivotValue) <= 0)
                {
                    this.Swap(collection, i, storeIndex);
                    storeIndex += 1;
                }
            }

            this.Swap(collection, storeIndex, rightIndex);
            return storeIndex;
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
