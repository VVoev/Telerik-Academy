using System;
using System.Collections.Generic;

namespace Sorting
{
    static class QuickSortClass
    {
        public static T[] QuickSort<T>(this T[] array)
            where T : IComparable<T>
        {
            // x <  y -> x.CmpTo(y) <  0
            // x >= y -> x.CmpTo(y) >= 0

            if (array.Length < 2)
            {
                var sArray = new T[array.Length];
                Array.Copy(array, sArray, array.Length);
                return sArray;
            }

            T pivot = array[0];
            var left = new List<T>();
            var right = new List<T>();
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }

            var leftSorted = left.ToArray().QuickSort();
            var rightSorted = right.ToArray().QuickSort();

            var sortedArray = new T[array.Length];
            for (int i = 0; i < leftSorted.Length; ++i)
            {
                sortedArray[i] = leftSorted[i];
            }

            sortedArray[leftSorted.Length] = pivot;

            for (int i = 0; i < rightSorted.Length; ++i)
            {
                sortedArray[leftSorted.Length + 1 + i] = rightSorted[i];
            }

            Console.WriteLine(string.Join(" ", sortedArray));

            return sortedArray;
        }

        public static void QuickSortInplace<T>(this T[] array)
            where T : IComparable<T>
        {
            array.QuickSortInplace(0, array.Length);
        }

        private static void QuickSortInplace<T>(this T[] array, int left, int right)
            where T : IComparable<T>
        {
            if(right - left < 2)
            {
                return;
            }

            int middle = (left + right) / 2;
            int pivotIndex = 0;
            if(array[left].CompareTo(array[right - 1]) < 0
                ^ array[left].CompareTo(array[middle]) < 0)
            {
                pivotIndex = left;
            }
            else if(array[right - 1].CompareTo(array[left]) < 0
                ^ array[right - 1].CompareTo(array[middle]) < 0)
            {
                pivotIndex = right;
            }
            else
            {
                pivotIndex = middle;
            }

            if(pivotIndex != left)
            {
                var tmp = array[pivotIndex];
                array[pivotIndex] = array[left];
                array[left] = tmp;
            }

            var pivot = array[left];

            int leftIndex = left + 1;
            int rightIndex = right - 1;

            while(leftIndex < rightIndex)
            {
                if(array[leftIndex].CompareTo(pivot) < 0)
                {
                    ++leftIndex;
                    continue;
                }

                if(array[rightIndex].CompareTo(pivot) >= 0)
                {
                    --rightIndex;
                    continue;
                }

                var tmp = array[leftIndex];
                array[leftIndex] = array[rightIndex];
                array[rightIndex] = tmp;
            }

            middle = leftIndex;
            if (array[middle].CompareTo(pivot) >= 0)
            {
                --middle;
            }

            if (middle != left)
            {
                array[left] = array[middle];
                array[middle] = pivot;
            }

            array.QuickSortInplace(left, middle);
            array.QuickSortInplace(middle + 1, right);
        }
    }
}
