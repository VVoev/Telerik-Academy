using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructures.DataStructures.Queue.DoubleEndedQueue
{
    public class DoubleEndedQueue<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] elements;
        private int startIndex;
        private int endIndex;
        private int elementsCount;

        public DoubleEndedQueue(int size = InitialCapacity)
        {
            this.elements = new T[size];
            this.startIndex = 0;
            this.endIndex = 0;
            this.elementsCount = 0;
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
        }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public void PushBack(T value)
        {
            this.EnsureCapacity();

            this.elements[endIndex] = value;
            this.endIndex = GetNextIndex(this.endIndex);
            this.elementsCount++;
        }

        public void PushFront(T value)
        {
            this.EnsureCapacity();

            this.startIndex = this.GetPrevIndex(this.startIndex);
            this.elements[startIndex] = value;
            this.elementsCount++;
        }

        public T PopBack()
        {
            this.endIndex = this.GetPrevIndex(this.endIndex);
            var poppedElement = this.elements[endIndex];
            this.elementsCount--;

            return poppedElement;
        }

        public T PopFront()
        {
            var poppedElement = this.elements[this.startIndex];
            this.startIndex = this.GetNextIndex(this.startIndex);
            this.elementsCount--;

            return poppedElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0, index = this.startIndex; i < this.elementsCount; i++ , index = this.GetNextIndex(index))
            {
                yield return this.elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetNextIndex(int index)
        {
            if (index + 1 < this.elements.Length)
            {
                return ++index;
            }
            else
            {
                return 0;
            }
        }

        private int GetPrevIndex(int index)
        {
            if (index == 0)
            {
                return this.elements.Length - 1;
            }
            else
            {
                return --index;
            }
        }

        private void EnsureCapacity()
        {
            if (this.elementsCount < this.elements.Length)
            {
                return;
            }

            var newElements = new T[this.elements.Length * 2];

            for (int i = 0, startIndex = this.startIndex; i < this.elementsCount; i++, startIndex = this.GetNextIndex(startIndex))
            {
                newElements[i] = this.elements[startIndex];
            }

            this.startIndex = 0;
            this.endIndex = this.elementsCount;
            this.elements = newElements;
        }
    }
}