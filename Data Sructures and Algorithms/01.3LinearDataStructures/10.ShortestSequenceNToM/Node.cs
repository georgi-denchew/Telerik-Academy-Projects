namespace _10.ShortestSequenceNToM
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node()
        {
            this.ChildNodes = new HashSet<Node<T>>();
        }

        public Node(T value)
            : this()
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public HashSet<Node<T>> ChildNodes { get; set; }
    }
}
