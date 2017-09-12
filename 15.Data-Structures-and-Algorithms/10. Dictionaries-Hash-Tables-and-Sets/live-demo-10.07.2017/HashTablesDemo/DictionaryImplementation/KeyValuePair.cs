namespace DictionaryImplementation
{
    public class KeyValuePair<K, V>
    {
        private readonly K key;

        public K Key => key;
        public V Value { get; set; }

        public KeyValuePair(K key, V value)
        {
            this.key = key;
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            var other = obj as KeyValuePair<K, V>;
            return this.key.Equals(other.key);
        }

        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }
    }
}
