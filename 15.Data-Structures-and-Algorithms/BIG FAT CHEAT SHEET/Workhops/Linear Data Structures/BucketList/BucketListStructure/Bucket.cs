using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructuresWorkshop.BucketListStrcuture
{
    public class Bucket<T> : IEnumerable<T>
    {
        private T[] elements;
        private int elementsCount;
        private int startIndex;

        public Bucket(int size)
        {
            this.elements = new T[size];
            this.elementsCount = 0;
            this.startIndex = 0;
            this.Size = size;
        }

        public Bucket(Bucket<T> firstBucket, Bucket<T> secondBucket)
        {
            this.Size = firstBucket.Size + secondBucket.Size;
            this.startIndex = 0;
            this.elements = new T[this.Size];
            this.elementsCount = firstBucket.Size + secondBucket.Size;

            for (int i = 0; i < firstBucket.Size; i++)
            {
                this.elements[i] = firstBucket[i];
            }

            for (int i = 0; i < secondBucket.Size; i++)
            {
                this.elements[i + firstBucket.Size] = secondBucket[i];
            }
        }

        public Bucket(bool left, Bucket<T> bucket)
        {
            int startIndex = left ? 0 : bucket.elementsCount / 2;
            int endIndex = left ? bucket.elementsCount / 2 : bucket.elementsCount;

            this.elementsCount = bucket.elementsCount / 2;
            this.startIndex = 0;
            this.Size = bucket.Size / 2;
            this.elements = new T[this.Size];

            for (int i = 0; startIndex < endIndex; i++, startIndex++)
            {
                this.elements[i] = bucket[startIndex];
            }
        }

        public int Size { get; private set; }

        private int EndIndex
        {
            get
            {
                return this.GetPrevIndex(this.startIndex);
            }
        }

        public bool Full
        {
            get
            {
                return this.elementsCount == this.elements.Length;
            }
        }

        public bool Empty
        {
            get
            {
                return this.elementsCount == 0;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.elements[this.AdaptIndex(index)];
            }

            set
            {
                this.elements[this.AdaptIndex(index)] = value;
            }
        }

        public void PushFront(T value)
        {
            this.startIndex = this.GetPrevIndex(this.startIndex);
            this.elements[this.startIndex] = value;
            if (!this.Full)
            {
                this.elementsCount++;
            }
        }

        public void PushBack(T value)
        {
            if (this.Full)
            {
                throw new ArgumentException("Cannot PushBack to a full bucket!");
            }

            int lastElementIndex = this.AdaptIndex(this.elementsCount);
            this.elements[lastElementIndex] = value;
            this.elementsCount++;
        }

        public T PopFront()
        {
            if (this.elementsCount == 0)
            {
                return default(T);
            }

            var targetElement = this.elements[this.startIndex];
            this.elements[this.startIndex] = default(T);
            this.startIndex = this.GetNextIndex(this.startIndex);
            this.elementsCount--;

            return targetElement;
        }

        public void Add(T value)
        {
            this.InsertAt(this.elementsCount, value);
        }

        public void InsertAt(int index, T value)
        {
            if (index < 0 || index > this.elementsCount || index >= this.elements.Length)
            {
                throw new IndexOutOfRangeException("Index must be withins the bounds of the bucket!");
            }

            int targetIndex = this.AdaptIndex(index);

            int currentIndex = this.EndIndex;
            int prevIndex = this.GetPrevIndex(currentIndex);

            while (currentIndex != targetIndex)
            {
                this.elements[currentIndex] = this.elements[prevIndex];

                currentIndex = this.GetPrevIndex(currentIndex);
                prevIndex = this.GetPrevIndex(prevIndex);
            }

            this.elements[targetIndex] = value;
            if (!this.Full)
            {
                this.elementsCount++;
            }
        }

        public void Remove(int index)
        {
            int targetIndex = this.AdaptIndex(index);

            int currentIndex = targetIndex;
            int nextIndex = this.GetNextIndex(currentIndex);

            while (currentIndex != this.EndIndex)
            {
                this.elements[currentIndex] = this.elements[nextIndex];

                currentIndex = nextIndex;
                nextIndex = this.GetNextIndex(nextIndex);
            }

            this.elements[this.EndIndex] = default(T);
            this.elementsCount--;
        }

        private int GetPrevIndex(int index)
        {
            if (index == 0)
            {
                return this.elements.Length - 1;
            }

            return index - 1;
        }

        private int GetNextIndex(int index)
        {
            if (index == this.elements.Length - 1)
            {
                return 0;
            }

            return index + 1;
        }

        private int AdaptIndex(int index)
        {
            int realIndex = index + this.startIndex;
            if (realIndex >= this.elements.Length)
            {
                realIndex -= this.elements.Length;
            }

            return realIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0, currentIndex = this.startIndex; i < this.elementsCount; i++, currentIndex = this.GetNextIndex(currentIndex))
            {
                yield return this.elements[currentIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
