namespace LinearDataStructures.DataStructures.Stack
{
    public class StackItem<T>
    {
        public StackItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public StackItem<T> Prev { get; internal set; }
    }
}
