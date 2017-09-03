using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinumimSpanningTreeKruskal
{
    public class PriorityQueue<T> : IEnumerable<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compareFunc;

        public PriorityQueue(Func<T, T, bool> compareFunc)
        {
            this.heap = new List<T>();
            this.heap.Add(default(T));
            this.compareFunc = compareFunc;
        }

        public int Count => this.heap.Count - 1;

        public T Top => this.heap[1];

        public bool IsEmpty => this.heap.Count <= 1;

        public void Insert(T value)
        {
            this.heap.Add(default(T));

            int index = this.heap.Count - 1;
            while (index > 1)
            {
                if (this.compareFunc(this.heap[index / 2], value))
                {
                    this.heap[index] = heap[index / 2];
                }
                else
                {
                    break;
                }

                index /= 2;
            }

            this.heap[index] = value;
        }

        public void Enqueue(T value)
        {
            this.Insert(value);
        }

        public T Dequeue()
        {
            if (this.Count > 0)
            {
                var returnValue = this.Top;
                this.RemoveTop();
                return returnValue;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }

        public void RemoveTop()
        {
            var value = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);

            if (!this.IsEmpty)
            {
                this.HeapifyDown(1, value);
            }
        }

        public void HeapifyDown(int initialIndex, T value)
        {
            int index = initialIndex;
            while (index * 2 + 1 < this.heap.Count)
            {
                int leftKidIndex = index * 2;
                int rightKidIndex = index * 2 + 1;

                int smallerKidIndex =
                    this.compareFunc(this.heap[leftKidIndex], this.heap[rightKidIndex]) ?
                    rightKidIndex :
                    leftKidIndex;

                if (this.compareFunc(value, this.heap[smallerKidIndex]))
                {
                    this.heap[index] = this.heap[smallerKidIndex];
                }
                else
                {
                    break;
                }

                index = smallerKidIndex;
            }

            if (index * 2 < this.heap.Count)
            {
                int smallerKidIndex = index * 2;

                if (this.compareFunc(this.heap[smallerKidIndex], value))
                {
                    this.heap[index] = this.heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            this.heap[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 1; i < this.heap.Count; i++)
            {
                yield return this.heap[i];
            }
        }
    }
}
