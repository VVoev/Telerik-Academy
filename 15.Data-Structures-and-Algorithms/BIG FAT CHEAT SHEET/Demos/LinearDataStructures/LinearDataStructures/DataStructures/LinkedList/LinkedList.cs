using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructures.DataStructures.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private int elementsCount;

        public LinkedList()
        {
            this.First = null;
            this.Last = null;
            this.elementsCount = 0;
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
        }

        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public void AddFirst(T value)
        {
            if (this.First == null)
            {
                var newNode = new LinkedListNode<T>(value);
                this.First = newNode;
                this.Last = newNode;
                return;
            }

            this.AddBefore(this.First, value);
        }

        public void AddLast(T value)
        {
            if (this.Last == null)
            {
                var newNode = new LinkedListNode<T>(value);
                this.First = newNode;
                this.Last = newNode;
                return;
            }

            this.AddAfter(this.Last, value);
        }

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>(value);

            newNode.Prev = node.Prev;
            newNode.Next = node;
            node.Next.Prev = newNode;

            if (newNode.Prev != null)
            {
                newNode.Prev.Next = newNode;
            }
            else
            {
                this.First = newNode;
            }
        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>(value);
            newNode.Next = node.Next;
            newNode.Prev = node;
            newNode.Prev.Next = newNode;

            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
            else
            {
                this.Last = newNode;
            }

            this.elementsCount++;
        }

        public void RemoveLast()
        {
            if (this.Last == null)
            {
                return;
            }

            this.Remove(this.Last);
        }

        public void RemoveFirst()
        {
            if (this.First == null)
            {
                return;
            }

            this.Remove(this.First);
        }

        public void Remove(LinkedListNode<T> node)
        {
            this.elementsCount--;

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                this.First = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                this.Last = node.Prev;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.First;
            while(currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
