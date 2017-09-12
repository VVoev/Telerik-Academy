using System;
using System.Collections;
using System.Collections.Generic;

namespace ConvexHull
{
    class ListDualStack<T> : IEnumerable<T>
    {
        private T[] buffer;

        public int Count { get; private set; }

        public ListDualStack()
        {
            this.buffer = new T[4];
        }

        public T First => this.buffer[0];
        public T Last => this.buffer[this.Count - 1];
        public T SecondLast => this.buffer[this.Count - 2];

        public void Add(T value)
        {
            if (buffer.Length == this.Count)
            {
                var newBuffer = new T[this.Count * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newBuffer[i] = buffer[i];
                }
                buffer = newBuffer;
            }

            this.buffer[this.Count] = value;
            ++this.Count;
        }

        public void RemoveLast()
        {
            --this.Count;
            this.buffer[this.Count] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; ++i)
            {
                yield return this.buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
