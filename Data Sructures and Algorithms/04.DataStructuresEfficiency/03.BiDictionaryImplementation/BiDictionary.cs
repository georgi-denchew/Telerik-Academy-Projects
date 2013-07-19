using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _03.BiDictionaryImplementation
{
    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> firstDictionary;

        private MultiDictionary<K2, T> secondDictionary;

        public BiDictionary()
        {
            this.firstDictionary = new MultiDictionary<K1, T>(true);
            this.secondDictionary = new MultiDictionary<K2, T>(true);
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            this.firstDictionary.Add(key1, value);
            this.secondDictionary.Add(key2, value);
        }

        public ICollection<T> FindElementsByFirstKey(K1 key)
        {
            ICollection<T> elements = firstDictionary[key];
            return elements;
        }

        public ICollection<T> FindElementsBySecondKey(K2 key)
        {
            ICollection<T> elements = secondDictionary[key];
            return elements;
        }

        public IEnumerable<T> FindElementsByBothKeys(K1 key1, K2 key2)
        {
            var key1Elements = firstDictionary[key1];

            var key2Elements = secondDictionary[key2];

            IEnumerable<T> result = key1Elements.Intersect(key2Elements);

            return result;
        }
    }
}
