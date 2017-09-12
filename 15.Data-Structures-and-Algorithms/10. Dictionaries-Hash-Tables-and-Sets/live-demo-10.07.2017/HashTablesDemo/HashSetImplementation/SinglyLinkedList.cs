using System;
using System.Collections;
using System.Collections.Generic;

namespace HashSetImplementation
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private T value;
        private SinglyLinkedList<T> next;

        public SinglyLinkedList(T value, SinglyLinkedList<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public bool Contains(T value)
        {
            var node = this;
            while(node != null)
            {
                if (node.value.Equals(value))
                {
                    return true;
                }
                node = node.next;
            }

            return false;
            //if(this.value.Equals(value))
            //{
            //    return true;
            //}
            //if(this.next == null)
            //{
            //    return false;
            //}
            //return this.next.Contains(value);
        }

        public SinglyLinkedList<T> Remove(T value, out bool removed)
        {
            if(this.value.Equals(value))
            {
                removed = true;
                return this.next;
            }

            if(this.next == null)
            {
                removed = false;
                return this;
            }

            this.next = this.next.Remove(value, out removed);
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this;
            while(node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
