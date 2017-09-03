using System;
using System.Collections.Generic;
using System.Collections;

namespace DictionariesHashTablesSets.DictionaryImplementation
{
    using DictionariesHashTablesSets.HashSetImplementation;

    public class Dictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private HashSet<KeyValuePair<K, V>> set;
        private int size;

        public Dictionary()
        {
            this.set = new HashSet<KeyValuePair<K, V>>();
            this.size = 0;
        }

        public int Count => this.size;

        public V this[K index]
        {
            get
            {
                var targetPair = this.set.Find(new KeyValuePair<K, V>(index, default(V)));

                if (targetPair == null)
                {
                    return default(V);
                }

                return targetPair.Value;
            }
            set
            {
                var targetPair = this.set.Find(new KeyValuePair<K, V>(index, default(V)));
                if (targetPair == null)
                {
                    targetPair = new KeyValuePair<K, V>(index, value);
                    this.set.Add(targetPair);
                }

                targetPair.Value = value;
            }
        }

        public void Add(K key, V value)
        {
            var newPair = new KeyValuePair<K, V>(key, value);
            if (this.set.Contains(newPair))
            {
                throw new InvalidOperationException("Dictionary already contains such key!");
            }

            var isAdded = this.set.Add(newPair);
            this.size = isAdded ? this.size + 1 : this.size;
        }

        public bool Remove(K key)
        {
            bool isRemoved = this.set.Remove(new KeyValuePair<K, V>(key, default(V)));
            this.size = isRemoved ? this.size - 1 : this.size;

            return isRemoved;
        }

        public bool ContainsKey(K key)
        {
            return this.set.Contains(new KeyValuePair<K, V>(key, default(V)));
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var elem in this.set)
            {
                yield return elem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
