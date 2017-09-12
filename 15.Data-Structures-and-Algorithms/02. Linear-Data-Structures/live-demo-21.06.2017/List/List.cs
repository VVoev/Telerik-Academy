using System;
using System.Collections;
using System.Collections.Generic;

namespace ListDataStructure
{
    public class List<T> : IEnumerable<T>
    {
        private T[] buffer;
        private int size;
        private const int MIN_CAPACITY = 4;

        public List()
        {
            buffer = null;
            size = 0;
        }

        public int Size => size;
        public int Capacity => buffer.Length;

        public void Add(T value)
        {
            PushBack(value);
        }

        public void PushBack(T value)
        {
            if (buffer == null)
            {
                buffer = new T[MIN_CAPACITY];
            }
            else if (size == buffer.Length)
            {
                Reserve(size * 2);
            }

            buffer[size] = value;
            ++size;
        }

        public void InsertAt(int index, T value)
        {
            if (index == size)
            {
                PushBack(value);
                return;
            }

            PushBack(Last);

            for (int i = size - 2; i > index; --i)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[index] = value;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < size - 1; ++i)
            {
                buffer[i] = buffer[i + 1];
            }

            PopBack();
        }

        public void RemoveRange(int begin, int end)
        {
            int rangeSize = end - begin;
            for (int i = begin; i < size - rangeSize; ++i)
            {
                buffer[i] = buffer[i + rangeSize];
            }
            for (int i = 0; i < rangeSize; ++i)
            {
                PopBack();
            }
        }

        public void PopBack()
        {
            if (size == 0)
            {
                throw new IndexOutOfRangeException("Poping from empty list");
            }

            --size;
            buffer[size] = default(T);
        }

        public void Reserve(int newSize)
        {
            if (newSize < size)
            {
                return;
            }

            var newBuffer = new T[newSize];
            for (int i = 0; i < size; ++i)
            {
                newBuffer[i] = buffer[i];
            }
            buffer = newBuffer;
        }

        public void ShrinkToFit()
        {
            Reserve(size);
        }

        public void Clear()
        {
            size = 0;
            buffer = new T[MIN_CAPACITY]; // optional
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; ++i)
            {
                yield return buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return buffer[index];
            }
            set
            {
                buffer[index] = value;
            }
        }

        public T Last
        {
            get
            {
                return buffer[size - 1];
            }
            set
            {
                buffer[size - 1] = value;
            }
        }
    }
}
