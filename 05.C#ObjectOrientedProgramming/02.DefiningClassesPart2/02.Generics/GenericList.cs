namespace _02.Generics
{
    using System;

    public class GenericList<T> where T : IComparable, IComparable<T>
    {
        // Fields.
        private const int InitialCapacity = 4;
        private int count;
        private int capacity;
        private T[] list;

        // Properties.
        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value < InitialCapacity)
                {
                    throw new ArgumentOutOfRangeException("Capacity can not be less than Initial Capacity, which is set to be at least 1.");
                }
                else
                {
                    this.capacity = value;
                }
            }
        }
        public int Count
        {
            get { return this.count; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Count can not be less than 0.");
                }
                this.count = value;
            }
        }

        // Indexer for Genericlist
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range exception.");
                }
                return this.list[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range exception.");
                }
                this.list[index] = value;
            }
        }
       
        // Constructor.
        public GenericList(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.list = new T[this.Capacity];
        }

        // Methods.
        private void DoubleCapacity()
        {
            // Double the capacity when Count is half of the Capacity.
            T[] newlist = new T[this.Capacity];
            this.Capacity *= 2;
            for (int i = 0; i < this.Count; i++)
            {
                newlist[i] = this.list[i];
            }
            this.list = newlist;
        }
        public void Add(T element)
        {
            if (this.Count == this.Capacity / 2)
            {
                DoubleCapacity();
            }
            this.Count++;
            this.list[this.Count - 1] = element;
        }
        public int IndexAt(T element)
        {
            int index = -1;
            foreach (var item in list)
            {
                index++;
                if (item.CompareTo(element) == 0)
                {
                    return index;
                }
            }
            throw new ArgumentOutOfRangeException("Element doesn't exist in current collection");
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Can not remove index at this position, because it's outside of boundaries of current collection");
            }
            for (int i = index + 1; i < this.Count; i++)
            {
                this.list[i - 1] = this.list[i];
            }
            this.Count--;
        }
        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Can not insert element at this position, because it's outside of boundaries of current collection");
            }
            for (int i = this.Count - 1; i > index; i--)
            {
                this.list[i + 1] = this.list[i];
            }
            this.list[index] = element;
            this.Count++;
        }
        public void Clear()
        {
            this.Capacity = InitialCapacity;
            this.Count = 0;
            this.list = new T[this.Capacity];
        }
        public int IndexOf(T element)
        {
            int index = -1;
            foreach (var item in list)
            {
                index++;
                if (item.CompareTo(element) == 0)
                {
                    return index;
                }
            }
            return index = -1;
        }
        public T Max()
        {
            T max = default(T);
            if (this.Count > 0)
            {
                max = this.list[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.list[i].CompareTo(max) > 0)
                    {
                        max = this.list[i];
                    }
                }
            }
            return max;
        }
        public T Min()
        {
            T min = default(T);
            if (this.Count > 0)
            {
                min = this.list[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.list[i].CompareTo(min) < 0)
                    {
                        min = this.list[i];
                    }
                }
            }
            return min;
        }

        public override string ToString()
        {
            string[] temp = new string[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                temp[i] = this.list[i].ToString();
            }
            return String.Join(", ", temp);
        }
    }
}
