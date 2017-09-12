using System.Collections;
using System.Collections.Generic;

namespace HashSetImplementation
{
    public class HashSet<T> : IEnumerable<T>
    {
        private const int MIN_BUFFER_LENGTH = 16;
        private const int RESIZE_FACTOR = 4;
        private const double FULL_PERCENTAGE = 0.5;

        private SinglyLinkedList<T>[] buffer;
        private List<uint> usedIndeces;

        public int Count { get; private set; }

        public HashSet()
        {
            this.buffer = new SinglyLinkedList<T>[MIN_BUFFER_LENGTH];
            this.usedIndeces = new List<uint>();
            this.Count = 0;
        }

        public bool Add(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = (uint)(hash % buffer.Length);

            var existed = buffer[index] != null && buffer[index].Contains(value);
            if (existed)
            {
                return false;
            }

            ++this.Count;
            if((double)this.Count / buffer.Length > FULL_PERCENTAGE)
            {
                this.Resize(buffer.Length * RESIZE_FACTOR);
                index = (uint)(hash % buffer.Length);
            }

            if(buffer[index] == null)
            {
                this.usedIndeces.Add(index);
            }
            buffer[index] = new SinglyLinkedList<T>(value, buffer[index]);

            return true;
        }

        public bool Contains(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = hash % buffer.Length;

            return buffer[index] != null && buffer[index].Contains(value);
        }

        public bool Remove(T value)
        {
            var hash = (uint)(value.GetHashCode());
            var index = hash % buffer.Length;

            if (buffer[index] == null)
            {
                return false;
            }

            bool removed;
            buffer[index] = buffer[index].Remove(value, out removed);
            if (removed)
            {
                --this.Count;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var index in this.usedIndeces)
            {
                if (this.buffer[index] == null)
                {
                    continue;
                }
                foreach (var x in this.buffer[index])
                {
                    yield return x;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize(int newSize)
        {
            var newBuffer = new SinglyLinkedList<T>[newSize];
            var newIndeces = new List<uint>();

            foreach (var x in this)
            {
                var hash = (uint)(x.GetHashCode());
                var index = (uint)(hash % newSize);
                if(newBuffer[index] == null)
                {
                    newIndeces.Add(index);
                }
                newBuffer[index] = new SinglyLinkedList<T>(x, newBuffer[index]);
            }

            this.buffer = newBuffer;
            this.usedIndeces = newIndeces;
        }
    }
}
