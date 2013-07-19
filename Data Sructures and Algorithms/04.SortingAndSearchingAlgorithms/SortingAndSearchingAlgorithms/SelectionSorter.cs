namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int iMin = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[iMin]) == -1)
                    {
                        iMin = j;
                    }
                }
                if (iMin != i)
                {
                    Swap(collection, i, iMin);
                }
            }
        }

        public static void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
