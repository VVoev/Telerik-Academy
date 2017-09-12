using System;
using System.Collections;
using System.Collections.Generic;

namespace HashSetImplementation
{
    public class HashSetWithLists<T> : IEnumerable<T>
    {
        private const int MIN_BUFFER_LENGTH = 16;
        private const int RESIZE_FACTOR = 4;
        private const double FULL_PERCENTAGE = 0.8;

        private List<T>[] buffer;
        private List<uint> usedIndeces;

        public int Count { get; private set; }

        public HashSetWithLists()
        {
            this.buffer = new List<T>[MIN_BUFFER_LENGTH];
            this.usedIndeces = new List<uint>();
            this.Count = 0;
        }

        public bool Add(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = (uint)(hash % buffer.Length);

            var existed = buffer[index] != null && buffer[index].Contains(value);
            if (existed)
            {
                return false;
            }

            ++this.Count;
            if ((double)this.Count / buffer.Length > FULL_PERCENTAGE)
            {
                this.Resize(buffer.Length * RESIZE_FACTOR);
                index = (uint)(hash % buffer.Length);
            }

            if (buffer[index] == null)
            {
                this.usedIndeces.Add(index);
                buffer[index] = new List<T>();
            }
            buffer[index].Add(value);

            return true;
        }

        public bool Contains(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = hash % buffer.Length;

            return buffer[index] != null && buffer[index].Contains(value);
        }

        public T Find(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = (uint)(hash % buffer.Length);
            if (buffer[index] == null)
            {
                return default(T);
            }

            var indexInList = buffer[index].IndexOf(value);
            if (indexInList < 0)
            {
                return default(T);
            }
            return buffer[index][indexInList];
        }

        public bool Remove(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = hash % buffer.Length;

            if (buffer[index] == null)
            {
                return false;
            }

            bool removed = buffer[index].Remove(value);
            if (removed)
            {
                --this.Count;
                return true;
            }

            return false;
        }

        public int GetMaxCount()
        {
            var max = 0;
            foreach (var index in this.usedIndeces)
            {
                if (buffer[index] != null && max < buffer[index].Count)
                {
                    max = buffer[index].Count;
                }
            }
            return max;
        }

        public double GetAverageCount()
        {
            int sum = 0;
            foreach (var index in this.usedIndeces)
            {
                if (buffer[index] != null)
                {
                    sum += buffer[index].Count;
                }
            }
            return (double)sum / buffer.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var index in this.usedIndeces)
            {
                if (this.buffer[index] == null)
                {
                    continue;
                }
                foreach (var x in this.buffer[index])
                {
                    yield return x;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize(int newSize)
        {
            var newBuffer = new List<T>[newSize];
            var newIndeces = new List<uint>();

            foreach (var x in this)
            {
                var hash = (uint)(x.GetHashCode());
                var index = (uint)(hash % newSize);
                if (newBuffer[index] == null)
                {
                    newIndeces.Add(index);
                    newBuffer[index] = new List<T>();
                }
                newBuffer[index].Add(x);
            }

            this.buffer = newBuffer;
            this.usedIndeces = newIndeces;
        }
    }
}
