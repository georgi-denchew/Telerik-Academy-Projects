using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.HashTableImplementation;

namespace _05.HashSetImplementation
{
    public class HashSet<T>
    {
        private HashTable<T, T> table;

        public HashSet()
        {
            this.Table = new HashTable<T, T>();
        }

        public HashTable<T, T> Table
        {
            get 
            { 
                return this.table; 
            }

            private set 
            { 
                this.table = value; 
            }
        }

        public int Count 
        {
            get
            {
                return this.Table.Count;
            }
        }

        public void Add(T value)
        {
            this.Table.Add(value, value);
        }

        public void Remove(T value)
        {
            this.Table.Remove(value);
        }

        public void Clear()
        {
            this.Table.Clear();
        }

        public IEnumerable<T> Union(HashSet<T> secondSet)
        {
            LinkedList<T> list = new LinkedList<T>();

            foreach (var item in this.Table)
            {
                list.AddLast(item.Value);
            }

            foreach (var item in secondSet.Table)
            {
                bool elementNotInFirstTable = (this.Table.Find(item.Key) as IComparable)
                    .CompareTo(item.Value) != 0;
               
                if (elementNotInFirstTable)
                {
                    list.AddLast(item.Value);
                }
            }

            return list.ToArray();
        }

        public IEnumerable<T> Intersect(HashSet<T> secondSet)
        {
            LinkedList<T> list = new LinkedList<T>();

            foreach (var item in secondSet.Table)
            {
                bool elementInBothTables = (this.Table.Find(item.Key) as IComparable)
                    .CompareTo(item.Value) == 0;

                if (elementInBothTables)
                {
                    list.AddLast(item.Value);
                }
            }

            return list.ToArray();
        }
    }
}
