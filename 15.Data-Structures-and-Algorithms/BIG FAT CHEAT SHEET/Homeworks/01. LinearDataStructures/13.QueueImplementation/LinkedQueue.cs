using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueImplementation
{
    public class LinkedQueue<T> : IEnumerable<T>
    {
        private QueueItem<T> firstElement;

        public void Enqueue(T value)
        {
            var elementToAdd = new QueueItem<T>(value);
            if (this.firstElement == null)
            {
                this.firstElement = elementToAdd;
            }
            else
            {
                var currentElement = this.firstElement;
                while(currentElement.NextItem != null)
                {
                    currentElement = currentElement.NextItem;
                }

                currentElement.NextItem = elementToAdd;
            }
        }

        public T Dequeue()
        {
            if (this.firstElement == null)
            {
                throw new InvalidOperationException("No element in the queue to be dequeued!");
            }

            var returnValue = this.firstElement.Value;
            this.firstElement = this.firstElement.NextItem;

            return returnValue;
        }

        public T Peek()
        {
            if (this.firstElement == null)
            {
                throw new InvalidOperationException("No element in the queue to be peeked at!");
            }

            var returnValue = this.firstElement.Value;
            return returnValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.firstElement;
            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
