using System.Collections;
using System.Collections.Generic;

namespace DictionariesHashTablesSets.HashSetImplementation
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private T value;
        private SinglyLinkedList<T> next;

        public SinglyLinkedList(T value)
        {
            this.value = value;
            this.next = null;
        }

        public T Value => value;

        public SinglyLinkedList<T> Attach(SinglyLinkedList<T> node)
        {
            node.next = this;
            return node;
        }

        public bool Contains(T value)
        {
            var node = this;
            while (node != null)
            {
                if (node.value.Equals(value))
                {
                    return true;
                }

                node = node.next;
            }

            return false;
        }

        public SinglyLinkedList<T> Find(T value)
        {
            var node = this;
            while (node != null)
            {
                if (node.value.Equals(value))
                {
                    return node;
                }

                node = node.next;
            }

            return null;
        }

        public SinglyLinkedList<T> Remove(T value, out bool isRemoved)
        {
            isRemoved = false;
            if (this.value.Equals(value))
            {
                isRemoved = true;
                return this.next;
            }

            if (this.next == null)
            {
                return this;
            }

            this.next = this.next.Remove(value, out isRemoved);
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this;
            while (currentNode != null)
            {
                yield return currentNode.value;
                currentNode = currentNode.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var objAsLinkedList = obj as SinglyLinkedList<T>;
            return this.value.Equals(objAsLinkedList.value);
        }
    }
}
