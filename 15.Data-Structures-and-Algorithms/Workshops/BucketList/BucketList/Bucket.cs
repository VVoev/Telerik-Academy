using System;

namespace BucketList
{
   public class Bucket<T>
    {
        private T[] buffer;
        private int startIndex;
        private int endIndex;
        private int size;

        public Bucket(int bucketSize)
        {
            buffer = new T[bucketSize];
            startIndex = 0;
            endIndex = 0;
            size = 0;
        }

        public bool Full => size == buffer.Length;

        public T this [int index]
        {
            get
            {
                return this.buffer[AdaptIndex(index)];
            }
            set
            {
                this.buffer[AdaptIndex(index)] = value;
            }
        }

        public void PushFront(T value)
        {
            startIndex = PrevIndex(startIndex);
            buffer[startIndex] = value;

            if (Full)
            {
                endIndex = startIndex;
            }

            else
            {
                size++;
            }
        }

        public void Insert(int index, T value)
        {
            int destinationIndex = endIndex;
            int sourceIndex = PrevIndex(destinationIndex);

            while (destinationIndex != index)
            {
                buffer[destinationIndex] = buffer[sourceIndex];
                destinationIndex = sourceIndex;
                sourceIndex = PrevIndex(sourceIndex);
            }

            buffer[index] = value;

            endIndex = NextIndex(endIndex);

            if (Full)
            {
                startIndex = endIndex;
            }
            else
            {
                ++size;
            }
        }

        private int AdaptIndex(int index)
        {
            int realIndex = startIndex + index;
            if(realIndex > buffer.Length)
            {
                realIndex -= buffer.Length;
            }

            return realIndex;
        }

        private int PrevIndex(int index)
        {
            if(index == 0)
            {
                return buffer.Length - 1;
            }

            return index - 1;
        }

        private int NextIndex(int index)
        {
            if(index == buffer.Length - 1)
            {
                return 0;
            }
            return index + 1;
        }
    }
}
