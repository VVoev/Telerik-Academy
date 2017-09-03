using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.ArrayExtensions
{
    public static class ArrayExtensions
    {
        public static T[] SelectionSort<T>(this T[] array)
            where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T swap = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = swap;
                }
            }

            return array;
        }

        public static T[] BubbleSort<T>(this T[] array)
            where T : IComparable<T>
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        T swap = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = swap;
                        swapped = true;
                    }
                }
            }

            return array;
        }

        public static T[] InsertionSort<T>(this T[] array)
            where T : IComparable<T>
        {
            var sortedArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int j;
                for (j = 0; j < i; j++)
                {
                    if (sortedArray[j].CompareTo(array[i]) > 0)
                    {
                        break;
                    }
                }

                for (int k = i; k > j; k--)
                {
                    sortedArray[k] = sortedArray[k - 1];
                }

                sortedArray[j] = array[i];
            }

            return sortedArray;
        }

        public static T[] QuickSort<T>(this T[] array)
            where T : IComparable<T>
        {
            if (array.Length < 2)
            {
                return array;
            }

            T pivot = array[0];

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 1; i < array.Length; i++)
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

            left = left.ToArray().QuickSort().ToList();
            right = right.ToArray().QuickSort().ToList();

            left.Add(pivot);
            left.AddRange(right);

            return left.ToArray();
        }

        public static void QuickSortInPlace<T>(this T[] array, int left, int right)
           where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            T pivot = array[left];

            int leftIndex = left + 1;
            int rightIndex = right - 1;

            while (leftIndex < rightIndex)
            {
                if (array[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                    continue;
                }

                if (array[rightIndex].CompareTo(pivot) >= 0)
                {
                    rightIndex--;
                    continue;
                }

                T swap = array[leftIndex];
                array[leftIndex] = array[rightIndex];
                array[rightIndex] = swap;
            }

            int middle = array[leftIndex].CompareTo(pivot) < 0 ? leftIndex : leftIndex - 1;

            if (middle != left)
            {
                array[left] = array[middle];
                array[middle] = pivot;
            }

            array.QuickSortInPlace(left, middle);
            array.QuickSortInPlace(middle + 1, right);
        }

        public static void MergeSort<T>(this T[] array, int left, int right)
            where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            int leftIndex = left;
            int rightIndex = right;
            int middleIndex = (left + right) / 2;

            array.MergeSort(leftIndex, middleIndex);
            array.MergeSort(middleIndex, right);

            Merge(array, leftIndex, middleIndex, rightIndex);
        }

        public static void MergeSort<T>(this T[] array)
            where T : IComparable<T>
        {
            array.MergeSort(0, array.Length);
        }
        // 3 8 1 7 2 4
        public static void Merge<T>(T[] array, int left, int middle, int right)
            where T : IComparable<T>
        {
            int leftIndex = left;
            int rightIndex = middle;

            T[] mergedArray = new T[right - left];

            int index = 0;
            while (leftIndex < middle || rightIndex < right)
            {
                if (leftIndex >= middle)
                {
                    mergedArray[index] = array[rightIndex];
                    rightIndex++;
                    index++;
                    continue;
                }

                if (rightIndex >= right)
                {
                    mergedArray[index] = array[leftIndex];
                    leftIndex++;
                    index++;
                    continue;
                }

                if (array[leftIndex].CompareTo(array[rightIndex]) <= 0)
                {
                    mergedArray[index] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[index] = array[rightIndex];
                    rightIndex++;
                }

                index++;
            }

            for (int i = left; i < right; i++)
            {
                array[i] = mergedArray[i - left];
            }
        }

        public static void CountSort(this int[] array, int maxElement)
        {
            int[] numbersCounts = new int[maxElement + 1];

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                numbersCounts[currentNumber]++;
            }

            int index = 0;
            for (int i = 0; i < numbersCounts.Length; i++)
            {
                for (int j = 0; j < numbersCounts[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }
        }

        public static void CountSort(this int[] array, int minElement, int maxElement)
        {
            int[] numbersCounts = new int[maxElement - minElement + 1];

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];

                numbersCounts[currentNumber - minElement]++;
            }

            int index = 0;
            for (int i = 0; i < numbersCounts.Length; i++)
            {
                for (int j = 0; j < numbersCounts[i]; j++)
                {
                    array[index] = i + minElement;
                    index++;
                }
            }
        }

        public static int LowerBound<T>(this T[] elements, T item)
           where T : IComparable<T>
        {
            return elements.Bound((el) => el.CompareTo(item) < 0);
        }


        public static int UpperBound<T>(this T[] elements, T item)
         where T : IComparable<T>
        {
            return elements.Bound((el) => el.CompareTo(item) <= 0);
        }

        public static int Bound<T>(this T[] elements, Func<T, bool> condition)
            where T : IComparable<T>
        {
            int startIndex = 0;
            int endIndex = elements.Length;

            int middleIndex = -1;
            while (startIndex < endIndex)
            {
                middleIndex = (startIndex + endIndex) / 2;
                if (condition(elements[middleIndex]))
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    endIndex = middleIndex;
                }
            }

            return startIndex;
        }

        public static void BinarySearchSort<T>(this T[] elements)
          where T : IComparable<T>
        {
            var sortedElements = new List<T>();

            foreach (var element in elements)
            {
                var index = sortedElements.ToArray().UpperBound(element);
                sortedElements.Insert(index, element);
            }

            sortedElements.CopyTo(elements);
        }

    }
}

// {25, 39, 93, 11, 55, 52, 90, 75, 43, 69, 64, 82, 66, 31, 47, 80, 26, 56, 10, 14, 38, 17, 21, 99, 30, 12, 44, 88, 24, 71};
