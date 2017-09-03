using System;
using System.Collections.Generic;

namespace TreesAndTreeTraversals.BinaryHeap
{
    public class BinaryHeap<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> compareFunc)
        {
            this.heap = new List<T>();
            this.heap.Add(default(T));
            this.compareFunc = compareFunc;
        }

        public int Count
        {
            get
            {
                return this.heap.Count - 1;
            }
        }

        public bool Empty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public T GetTop()
        {
            return this.heap[1];
        }

        public void Insert(T value)
        {
            this.heap.Add(value);

            int index = heap.Count - 1;
            while (index > 1 && this.compareFunc(this.heap[index / 2], value))
            {
                heap[index] = heap[index / 2];
                index /= 2;
            }

            heap[index] = value;
        }

        public void RemoveTop()
        {
            var value = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);

            int index = 1;
            if (!this.Empty)
            {
                this.HeapifyDown(index, value);
            }
        }

        public void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < this.heap.Count)
            {
                int leftChildIndex = index * 2;
                int rightChildIndex = (index * 2) + 1;

                int smallerChildIndex =
                    this.compareFunc(this.heap[leftChildIndex], this.heap[rightChildIndex]) ?
                   rightChildIndex :
                   leftChildIndex;
                if (this.compareFunc(value, this.heap[smallerChildIndex]))
                {
                    this.heap[index] = this.heap[smallerChildIndex];
                }
                else
                {
                    break;
                }

                index = smallerChildIndex;
            }

            if (index * 2 < this.heap.Count)
            {
                int smallerChildIndex = index * 2;

                if (this.compareFunc(value, this.heap[smallerChildIndex]))
                {
                    this.heap[index] = this.heap[smallerChildIndex];
                    index = smallerChildIndex;
                }
            }

            this.heap[index] = value;
        }
    }
}
