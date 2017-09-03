using System;
using System.Collections;
using System.Collections.Generic;

namespace _12.StackImplementation
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialDefaultCapacity = 4;

        private T[] elements;
        private int elementsCount = 0;

        public Stack()
            : this(InitialDefaultCapacity)
        {
        }

        public Stack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity must be a positive number!");
            }

            this.elements = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
        }

        public void Push(T value)
        {
            if (this.elementsCount >= this.elements.Length)
            {
                this.EnsureCapacity();
            }

            this.elements[elementsCount] = value;
            this.elementsCount++;
        }

        public T Pop()
        {
            if (elementsCount == 0)
            {
                throw new InvalidOperationException("No elements to pop out from the stack!");
            }

            var targetElement = this.elements[elementsCount - 1];

            this.elements[elementsCount - 1] = default(T);
            this.elementsCount--;

            return targetElement;
        }

        public T Peek()
        {
            if (this.elementsCount == 0)
            {
                throw new InvalidOperationException("No element to peek at in stack!");
            }

            var targetElement = this.elements[this.elementsCount - 1];
            return targetElement;
        }

        private void EnsureCapacity()
        {
            var newElements = new T[this.elements.Length * 2];
            for (int i =0; i < this.elements.Length; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elementsCount - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
