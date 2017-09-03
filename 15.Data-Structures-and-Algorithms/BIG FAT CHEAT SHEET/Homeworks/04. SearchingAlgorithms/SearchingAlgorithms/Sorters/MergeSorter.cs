using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHomework.Sorters
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> elements)
        {
            this.MergeSort(elements, 0, elements.Count);
        }

        private void MergeSort(IList<T> elements, int left, int right)
        {
            if (right - left < 2)
            {
                return;
            }

            int leftIndex = left;
            int rightIndex = right;
            int middleIndex = (leftIndex + rightIndex) / 2;

            this.MergeSort(elements, leftIndex, middleIndex);
            this.MergeSort(elements, middleIndex, rightIndex);

            this.Merge(elements, leftIndex, middleIndex, rightIndex);
        }

        private void Merge(IList<T> elements, int left, int middle, int right)
        {
            int leftIndex = left;
            int rightIndex = middle;

            var mergedArray = new T[right - left];

            int index = 0;
            while (leftIndex < middle || rightIndex < right)
            {
                if (leftIndex >= middle)
                {
                    mergedArray[index] = elements[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= right)
                {
                    mergedArray[index] = elements[leftIndex];
                    leftIndex++;
                }
                else if (elements[leftIndex].CompareTo(elements[rightIndex]) <= 0)
                {
                    mergedArray[index] = elements[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[index] = elements[rightIndex];
                    rightIndex++;
                }

                index++;
            }

            for (int i = 0; i < mergedArray.Length; i++)
            {
                elements[i + left] = mergedArray[i];
            }
        }
    }
}
