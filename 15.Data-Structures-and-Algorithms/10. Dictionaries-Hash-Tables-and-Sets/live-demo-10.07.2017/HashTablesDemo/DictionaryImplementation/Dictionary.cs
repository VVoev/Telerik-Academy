using System;
using System.Collections;
using System.Collections.Generic;

namespace DictionaryImplementation
{
    public class Dictionary<K, V> : IEnumerable<V>
    {
        private HashSetImplementation.HashSetWithLists<KeyValuePair<K, V>> set;

        public int Count => set.Count;

        public Dictionary()
        {
            set = new HashSetImplementation.HashSetWithLists<KeyValuePair<K, V>>();
        }

        public bool Add(K key, V value)
        {
            var item = new KeyValuePair<K, V>(key, value);
            return this.set.Add(item);
        }

        public bool ContainsKey(K key)
        {
            return this.set.Contains(new KeyValuePair<K, V>(key, default(V)));
        }

        public bool RemoveKey(K key)
        {
            return this.set.Remove(new KeyValuePair<K, V>(key, default(V)));
        }

        public KeyValuePair<K, V> Find(K key)
        {
            return this.set.Find(new KeyValuePair<K, V>(key, default(V)));
        }

        public IEnumerator<V> GetEnumerator()
        {
            foreach(var kvp in this.set)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key).Value;
            }
            set
            {
                var found = this.Find(key);
                if (found == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    found.Value = value;
                }
            }
        }
    }
}
