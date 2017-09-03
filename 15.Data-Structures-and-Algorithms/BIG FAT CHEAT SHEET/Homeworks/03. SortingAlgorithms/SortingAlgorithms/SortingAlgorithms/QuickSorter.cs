using System;

namespace SortingAlgorithms
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(T[] elements)
        {
            this.QuickSort(elements, 0, elements.Length);
        }

        private void QuickSort(T[] elements, int left, int right)
        {
            if (right - left < 2)
            {
                return;
            }

            T pivot = elements[left];

            int leftIndex = left + 1;
            int rightIndex = right - 1;

            while (leftIndex < rightIndex)
            {
                if (elements[leftIndex].CompareTo(pivot) <= 0)
                {
                    leftIndex++;
                }
                else if (elements[rightIndex].CompareTo(pivot) > 0)
                {
                    rightIndex--;
                }
                else
                {
                    T swap = elements[leftIndex];
                    elements[leftIndex] = elements[rightIndex];
                    elements[rightIndex] = swap;
                }
            }

            int middleIndex = elements[leftIndex].CompareTo(pivot) < 0 ? leftIndex : leftIndex - 1;

            elements[left] = elements[middleIndex];
            elements[middleIndex] = pivot; 

            this.QuickSort(elements, left, middleIndex);
            this.QuickSort(elements, middleIndex + 1, right);
        }
    }
}
