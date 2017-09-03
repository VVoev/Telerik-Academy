using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructures.DataStructures.List
{
    public class List<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] elements;
        private int elementsCount;

        public List(int size = InitialCapacity)
        {
            this.elements = new T[InitialCapacity];
            this.elementsCount = 0;
        }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndexRange(index);

                return this.elements[index];
            }
            set
            {
                this.ValidateIndexRange(index);
                this.elements[index] = value;
            }
        }

        public void Add(T value)
        {
            if (this.elementsCount == this.elements.Length)
            {
                EnsureCapacity(this.Capacity * 2);
            }

            this.elements[this.elementsCount] = value;
            this.elementsCount++;
        }

        public void InsertAt(int index, T value)
        {
            if (index < 0 || index > this.elementsCount)
            {
                throw new IndexOutOfRangeException("Index must be witin the bounds of the array!");
            }

            if (index == this.elementsCount)
            {
                this.Add(value);
                return;
            }

            if (this.elementsCount == this.elements.Length)
            {
                this.EnsureCapacity(this.Capacity * 2);
            }

            for (int i = elementsCount; i > index; i--)
            {
                this.elements[i] = elements[i - 1];
            }

            this.elements[index] = value;
            this.elementsCount++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndexRange(index);

            for (int i = index; i < this.elementsCount - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[this.elementsCount - 1] = default(T);
            this.elementsCount--;
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public void RemoveRange(int startIndex, int count)
        {
            this.ValidateIndexRange(startIndex);

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("count must be a positive number!");
            }

            for (int i = startIndex + count; i < this.elementsCount; i++)
            {
                this.elements[i - count] = this.elements[i];
            }

            for (int i = 0; i < count; i++)
            {
                this.elements[this.elementsCount - 1 - i] = default(T);
            }

            this.elementsCount -= count;
        }

        //public void RemoveRange(int startIndex, int endIndex)
        //{
        //    this.ValidateIndexRange(startIndex);
            
        //    if (endIndex > this.elementsCount)
        //    {
        //        throw new ArgumentNullException("End index cannot be greater than the list's count!");
        //    }

        //    if (startIndex > endIndex)
        //    {
        //        throw new ArgumentOutOfRangeException("Start index cannot be after end index!");
        //    }

        //    int elementsToRemoveCount = endIndex - startIndex;
        //    for (int i = endIndex; i < this.elementsCount; i++)
        //    {
        //        this.elements[i - elementsToRemoveCount] = this.elements[i];
        //    }

        //    for (int i = 0; i < elementsToRemoveCount; i++)
        //    {
        //        this.elements[this.elementsCount - i - 1] = default(T);
        //    }

        //    this.elementsCount -= elementsToRemoveCount;
        //}

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elementsCount; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureCapacity(int size)
        {
            if (size < this.elements.Length)
            {
                return;
            }

            var newElements = new T[size];
            for (int i = 0; i < elementsCount; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        private void ValidateIndexRange(int index)
        {
            if (index < 0 || index >= this.elementsCount)
            {
                throw new IndexOutOfRangeException("Index was out of the lists boundaries");
            }
        }
    }
}
