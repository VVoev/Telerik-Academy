using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructures.DataStructures.Queue.QueueList
{
    public class Queue<T> : IEnumerable<T>
    {
        private const int IntialCapacity = 4;

        private T[] elements;
        private int elementsCount;
        private int startIndex;
        private int endIndex;

        public Queue(int size = IntialCapacity)
        {
            this.elements = new T[size];
            this.elementsCount = 0;
            this.startIndex = 0;
            this.endIndex = 0;
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

        public void Enqueue(T value)
        {
            if (this.elementsCount == this.elements.Length)
            {
                this.EnsureCapacity(this.elements.Length * 2);
            }

            this.elements[endIndex] = value;

            this.endIndex = GetNextIndex(endIndex);
            this.elementsCount++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No item to dequeue!");
            }

            var targetElement = this.elements[startIndex];
            this.elements[startIndex] = default(T);

            this.elementsCount--;
            this.startIndex = this.GetNextIndex(startIndex);

            return targetElement;
        }

        public T Peek()
        {
            return this.elements[this.startIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0, startIndex = this.startIndex; i < this.elementsCount; i++, startIndex = this.GetNextIndex(startIndex))
            {
                yield return this.elements[startIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetNextIndex(int index)
        {
            if (index + 1 >= this.elements.Length)
            {
                return 0;
            }
            else
            {
                return ++index;
            }
        }

        private void EnsureCapacity(int size)
        {
            var newElements = new T[size];

            for (int i = 0, startIndex = this.startIndex; i < this.elementsCount; i++, startIndex = GetNextIndex(startIndex))
            {
                newElements[i] = this.elements[startIndex];
            }

            this.startIndex = 0;
            this.endIndex = this.elementsCount;
            this.elements = newElements;
        }
    }
}
