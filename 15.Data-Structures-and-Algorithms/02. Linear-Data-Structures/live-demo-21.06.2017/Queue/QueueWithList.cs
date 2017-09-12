namespace Queue
{
    public class QueueWithList<T>
    {
        private const int MIN_CAPACITY = 4;

        private T[] buffer;
        private int startIndex;
        private int size;
        private int endIndex;

        public QueueWithList()
        {
            buffer = null;
            startIndex = 0;
            size = 0;
            endIndex = 0;
        }

        public int Size => size;
        public bool Empty => size == 0;
        public T Front => buffer[startIndex];

        public void Push(T value)
        {
            if (buffer == null)
            {
                buffer = new T[MIN_CAPACITY];
            }
            else if (size == buffer.Length)
            {
                Reserve(size * 2);
            }

            buffer[endIndex] = value;
            endIndex = NextIndex(endIndex);
            ++size;
        }

        public void Pop()
        {
            buffer[startIndex] = default(T);
            startIndex = NextIndex(startIndex);
            --size;
        }

        public void Reserve(int newSize)
        {
            if (newSize < size)
            {
                return;
            }

            var newBuffer = new T[newSize];

            for (int i = 0, j = startIndex;
                i < size;
                ++i, j = NextIndex(j))
            {
                newBuffer[i] = buffer[j];
            }

            //int sourceIndex = startIndex;
            //int destinationIndex = 0;
            //while (sourceIndex != endIndex)
            //{
            //    newBuffer[destinationIndex] = buffer[sourceIndex];
            //    ++destinationIndex;
            //    sourceIndex = NextIndex(sourceIndex);
            //}

            startIndex = 0;
            endIndex = size;
            buffer = newBuffer;
        }

        private int NextIndex(int index)
        {
            ++index;
            if (index == buffer.Length)
            {
                index = 0;
            }
            return index;
        }
    }
}
