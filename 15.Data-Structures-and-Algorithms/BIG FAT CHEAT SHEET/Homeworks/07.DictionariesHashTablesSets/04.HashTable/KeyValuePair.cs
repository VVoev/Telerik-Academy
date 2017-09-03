namespace DictionariesHashTablesSets.DictionaryImplementation
{
    public class KeyValuePair<K, V>
    {
        public KeyValuePair(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }

        public K Key { get; private set; }

        public V Value { get; internal set; }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var objAsKVPair = obj as KeyValuePair<K, V>;
            return this.Key.Equals(objAsKVPair.Key);
        }
    }
}
