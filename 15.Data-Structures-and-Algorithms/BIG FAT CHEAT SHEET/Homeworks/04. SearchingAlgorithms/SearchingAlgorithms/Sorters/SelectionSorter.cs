using System;
using System.Collections.Generic;

namespace SortingHomework.Sorters
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (elements[minIndex].CompareTo(elements[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T swap = elements[minIndex];
                    elements[minIndex] = elements[i];
                    elements[i] = swap;
                }
            }
        }
    }
}
