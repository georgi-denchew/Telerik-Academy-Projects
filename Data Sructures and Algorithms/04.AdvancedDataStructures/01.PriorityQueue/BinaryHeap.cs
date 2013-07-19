namespace _01.PriorityQueue
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    //public class BinaryHeap<T>
    //    where T : IComparable
    //{
    //    private readonly BigList<T> _list;

    //    public BinaryHeap()
    //    {
    //        _list = new BigList<T>(); ;
    //        Count = 0;
    //        Heapify();
    //    }

    //    public int Count { get; private set; }

    //    public T PopRoot()
    //    {
    //        if (Count == 0) throw new InvalidOperationException("Empty heap.");
    //        var root = _list[0];
    //        SwapCells(0, Count - 1);
    //        Count--;
    //        HeapDown(0);
    //        return root;
    //    }

    //    public T PeekRoot()
    //    {
    //        if (Count == 0) throw new InvalidOperationException("Empty heap.");
    //        return _list[0];
    //    }

    //    public void Insert(T e)
    //    {
    //        if (Count >= _list.Count) _list.Add(e);
    //        else _list[Count] = e;
    //        Count++;
    //        HeapUp(Count - 1);
    //    }

    //    private void Heapify()
    //    {
    //        for (int i = Parent(Count - 1); i >= 0; i--)
    //        {
    //            HeapDown(i);
    //        }
    //    }

    //    private void HeapUp(int i)
    //    {
    //        T elt = _list[i];
    //        while (true)
    //        {
    //            int parent = Parent(i);
    //            if (parent < 0 || _list[parent].CompareTo(elt) > 0) break;
    //            SwapCells(i, parent);
    //            i = parent;
    //        }
    //    }

    //    private void HeapDown(int i)
    //    {
    //        while (true)
    //        {
    //            int lchild = LeftChild(i);
    //            if (lchild < 0) break;
    //            int rchild = RightChild(i);

    //            int child = rchild < 0
    //              ? lchild
    //              : _list[lchild].CompareTo(_list[rchild]) > 0 ? lchild : rchild;

    //            if (_list[child].CompareTo(_list[i]) < 0) break;
    //            SwapCells(i, child);
    //            i = child;
    //        }
    //    }

    //    private int Parent(int i) { return i <= 0 ? -1 : SafeIndex((i - 1) / 2); }

    //    private int RightChild(int i) { return SafeIndex(2 * i + 2); }

    //    private int LeftChild(int i) { return SafeIndex(2 * i + 1); }

    //    private int SafeIndex(int i) { return i < Count ? i : -1; }

    //    private void SwapCells(int i, int j)
    //    {
    //        T temp = _list[i];
    //        _list[i] = _list[j];
    //        _list[j] = temp;
    //    }
    //}

    public class BinaryHeap<T>
        where T : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Binary Heap<T>"/> class.
        /// </summary>
        public BinaryHeap()
        {
            this.Elements = new BigList<T>();
            this.Count = 0;
        }

        /// <summary>
        /// Gets the count of the numbers in the
        /// <see cref=" Binary Heap"/> instance.
        /// </summary>
        public int Count { get; private set; }

        public BigList<T> Elements { get; private set; }

        /// <summary>
        /// Removes the root element in the 
        /// <see cref="Binary Heap"/> instance and returns it.
        /// </summary>
        /// <returns>Returns the root element.</returns>
        public T PopRoot()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The heap is empty.");
            }

            T root = this.Elements[0];
            this.SwapCells(0, this.Count - 1);
            this.Count--;
            this.HeapDown(0);

            return root;
        }

        /// <summary>
        /// Gets the root element in the
        /// <see cref="Binary Heap"/> instance.
        /// </summary>
        /// <returns>Returns the root element.</returns>
        public T PeekRoot()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The heap is empty");
            }

            return this.Elements[0];
        }

        /// <summary>
        /// Inserts a new item in the given
        /// <see cref="Binary Heap"/> instance.
        /// </summary>
        /// <param name="item">Item to be inserted in the BinaryHeap</param>
        public void Insert(T item)
        {
            if (this.Count >= this.Elements.Count)
            {
                this.Elements.Add(item);
            }
            else
            {
                this.Elements[this.Count] = item;
            }

            this.Count++;
            this.HeapUp(this.Count - 1);
        }

        /// <summary>
        /// Iterates from top to bottom of the 
        /// <see cref="Binary Heap"/> instance and places
        /// the given element in it's proper position.
        /// </summary>
        private void HeapDown(int position)
        {
            while (true)
            {
                int leftChild = this.LeftChild(position);

                if (leftChild < 0)
                {
                    break;
                }

                int rightChild = this.RightChild(position);
                int child = 0;

                if (rightChild < 0)
                {
                    child = leftChild;
                }
                else
                {
                    if (this.Elements[leftChild].CompareTo(this.Elements[rightChild]) > 0)
                    {
                        child = leftChild;
                    }
                    else
                    {
                        child = rightChild;
                    }
                }

                if (this.Elements[child].CompareTo(this.Elements[position]) < 0)
                {
                    break;
                }

                this.SwapCells(position, child);
                position = child;
            }
        }

        /// <summary>
        /// Iterates from bottom to top of the 
        /// <see cref="Binary Heap"/> instance and places
        /// the given element in it's proper position.
        /// </summary>
        private void HeapUp(int position)
        {
            T element = this.Elements[position];

            while (true)
            {
                int parent = this.Parent(position);

                if (parent < 0 || this.Elements[parent].CompareTo(element) > 0)
                {
                    break;
                }

                this.SwapCells(position, parent);
                position = parent;
            }
        }

        private void SwapCells(int firstPosition, int secondPosition)
        {
            T temporary = this.Elements[firstPosition];
            this.Elements[firstPosition] = this.Elements[secondPosition];
            this.Elements[secondPosition] = temporary;
        }

        private int Parent(int position)
        {
            return position <= 0 ? -1 : this.IndexInRange((position - 1) / 2);
        }

        private int RightChild(int position)
        {
            return this.IndexInRange((2 * position) + 2);
        }

        private int LeftChild(int position)
        {
            return this.IndexInRange((2 * position) + 1);
        }

        private int IndexInRange(int position)
        {
            return position < this.Count ? position : -1;
        }
    }
}