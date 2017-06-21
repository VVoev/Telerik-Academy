namespace _11.CustomLinkedList
{
    public class Item<T>
    {
        public Item(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Item<T> NextItem { get; set; }
    }
}