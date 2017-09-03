using System;

namespace SortingAlgorithms
{
    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(T[] elements);
    }
}
