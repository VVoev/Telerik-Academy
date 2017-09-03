using System;
using System.Collections;
using System.Collections.Generic;

namespace DictionariesHashTablesSets.HashSetImplementation
{
    public class HashSet<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;
        private const int ResizeFactor = 2;
        private const double ResizeCoefficient = 0.5;

        private SinglyLinkedList<T>[] set;
        private int size;

        public HashSet(int capacity = InitialCapacity)
        {
            this.set = new SinglyLinkedList<T>[capacity];
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public bool Add(T value)
        {
            this.Resize();
            int index = this.GetIndex(value);
            if (this.Contains(value))
            {
                return false;
            }

            this.size++;
            if (this.set[index] == null)
            {
                this.set[index] = new SinglyLinkedList<T>(value);
                return true;
            }

            this.set[index] = this.set[index].Attach(new SinglyLinkedList<T>(value));
            return true;
        }

        public bool Contains(T value)
        {
            int index = this.GetIndex(value);
            if (this.set[index] == null || !this.set[index].Contains(value))
            {
                return false;
            }

            return true;
        }

        public T Find(T value)
        {
            int index = this.GetIndex(value);
            if (this.set[index] == null)
            {
                return default(T);
            }

            var targetNode = this.set[index].Find(value);
            if (targetNode == null)
            {
                return default(T);
            }

            return targetNode.Value;
        }

        public bool Remove(T value)
        {
            int index = this.GetIndex(value);
            if (this.set[index] == null)
            {
                return false;
            }

            bool isRemoved = false;
            this.set[index] = this.set[index].Remove(value, out isRemoved);
            if (isRemoved)
            {
                this.size--;
            }

            return isRemoved;
        }

        private void Resize()
        {
            if ((this.size / this.set.Length) < ResizeFactor)
            {
                return;
            }

            var newSize = this.size * ResizeFactor;
            var newSet = new SinglyLinkedList<T>[newSize];
            for (int i = 0; i < this.set.Length; i++)
            {
                if (this.set[i] == null)
                {
                    continue;
                }

                foreach (var node in this.set[i])
                {
                    int index = Math.Abs(node.GetHashCode()) % newSize;
                    if (newSet[index] == null)
                    {
                        newSet[index] = new SinglyLinkedList<T>(node);
                        continue;
                    }
                    else
                    {
                        newSet[index] = newSet[index].Attach(new SinglyLinkedList<T>(node));
                    }
                }
            }

            this.set = newSet;
            this.size = newSize;
        }

        public int GetIndex(T value)
        {
            int index = Math.Abs(value.GetHashCode()) % this.set.Length;
            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var subset in this.set)
            {
                if (subset == null)
                {
                    continue;
                }

                foreach (var element in subset)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
