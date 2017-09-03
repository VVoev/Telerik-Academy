namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public int LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (item.CompareTo(this.items[i]) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(T item)
        {
            int startIndex = 0;
            int endIndex = this.items.Count;
            //  0, 1, 2, 3, 18, 44, 90
            int middleIndex;
            while (startIndex < endIndex)
            {
                middleIndex = (startIndex + endIndex) / 2;
                if (this.items[middleIndex].CompareTo(item) == 0)
                {
                    return middleIndex;
                }
                else if (this.items[middleIndex].CompareTo(item) < 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex;
                }
            }

            return -1;
        }

        public void Shuffle()
        {
            var randomGenerator = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int randomIndex = randomGenerator.Next(0, this.items.Count);

                T swap = this.items[randomIndex];
                this.items[randomIndex] = this.items[i];
                this.items[i] = swap;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
