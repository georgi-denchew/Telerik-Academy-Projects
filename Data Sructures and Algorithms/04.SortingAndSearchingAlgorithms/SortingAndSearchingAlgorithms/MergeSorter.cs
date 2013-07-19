namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            List<T> sorted = this.MergeSort(collection).ToList();

            collection.Clear();
            
            foreach (var item in sorted)
            {
                collection.Add(item);
            }
        }
        
        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            List<T> leftList = new List<T>();
            List<T> rightList = new List<T>();
            int middleIndex = collection.Count / 2;

            for (int i = 0; i < middleIndex; i++)
            {
                leftList.Add(collection[i]);
            }

            for (int i = middleIndex; i < collection.Count; i++)
            {
                rightList.Add(collection[i]);
            }

            leftList = this.MergeSort(leftList).ToList();
            rightList = this.MergeSort(rightList).ToList();

            return this.Merge(leftList, rightList);
        }

        private IList<T> Merge(List<T> leftList, List<T> rightList)
        {
            List<T> result = new List<T>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList[0].CompareTo(rightList[0]) <= 0)
                    {
                        result.Add(leftList[0]);
                        leftList.Remove(leftList[0]);
                    }
                    else
                    {
                        result.Add(rightList[0]);
                        rightList.Remove(rightList[0]);
                    }
                }
                else if (leftList.Count > 0)
                {
                    result.Add(leftList[0]);
                    leftList.Remove(leftList[0]);
                }
                else if (rightList.Count > 0)
                {
                    result.Add(rightList[0]);
                    rightList.Remove(rightList[0]);
                }
            }

            return result;
        }
    }
}
