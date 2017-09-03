namespace QueueImplementation
{
    public class QueueItem<T>
    {
        public QueueItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public QueueItem<T> NextItem { get; set; }
    }
}
