using System;
using System.Threading;

namespace Sorting
{
    static class MergeSortClass
    {
        public static void MergeSort<T>(this T[] array)
            where T : IComparable<T>
        {
            array.MergeSort(0, array.Length);
        }

        private static void MergeSort<T>(this T[] array, int left, int right)
            where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            int middle = (left + right) / 2;

            array.MergeSort(left, middle);
            array.MergeSort(middle, right);

            array.Merge(left, middle, right);
        }

        private static void Merge<T>(this T[] array, int left, int middle, int right)
            where T : IComparable<T>
        {
            int i = left;
            int j = middle;
            int k = 0;

            var mergeArray = new T[right - left];

            while (k < mergeArray.Length)
            {
                if (i < middle && j < right)
                {
                    if (array[i].CompareTo(array[j]) <= 0) // <= to be stable
                    {
                        mergeArray[k] = array[i];
                        ++i;
                    }
                    else
                    {
                        mergeArray[k] = array[j];
                        ++j;
                    }
                }
                else if (i < middle)
                {
                    mergeArray[k] = array[i];
                    ++i;
                }
                else if (j < right)
                {
                    mergeArray[k] = array[j];
                    ++j;
                }
                else
                {
                    break;
                }

                ++k;
            }

            for (int t = 0; t < mergeArray.Length; ++t)
            {
                array[left + t] = mergeArray[t];
            }
        }

        public static void MergeSortIterative<T>(this T[] array)
            where T : IComparable<T>
        {
            for (int half = 1; half < array.Length; half *= 2)
            {
                for (int left = 0; left < array.Length; left += half * 2)
                {
                    int middle = left + half;
                    if (middle >= array.Length)
                    {
                        break;
                    }
                    int right = left + half * 2;
                    if (right > array.Length)
                    {
                        right = array.Length;
                    }

                    array.Merge(left, middle, right);
                }
            }
        }

        public static void MergeSortMultithreaded<T>(this T[] array)
            where T : IComparable<T>
        {
            array.MergeSortMultithreaded(0, array.Length);
        }

        private static void MergeSortMultithreaded<T>(this T[] array, int left, int right)
            where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            int middle = (left + right) / 2;

            if (runningThreads < MAX_RUNNING_THREADS)
            {
                ThreadStart leftSortTask = () => array.MergeSortMultithreaded(left, middle);
                var leftSortThread = new Thread(leftSortTask);
                leftSortThread.Start();

                ThreadStart rightSortTask = () => array.MergeSortMultithreaded(middle, right);
                var rightSortThread = new Thread(rightSortTask);
                rightSortThread.Start();

                runningThreads += 2;
                if (runningThreads > maxRunningThreads)
                {
                    maxRunningThreads = runningThreads;
                }

                leftSortThread.Join();
                rightSortThread.Join();

                runningThreads -= 2;
            }
            else
            {
                array.MergeSort(left, middle);
                array.MergeSort(middle, right);
            }

            array.Merge(left, middle, right);
        }

        private const int MAX_RUNNING_THREADS = 8;

        private static int runningThreads = 0;
        private static int maxRunningThreads = 0;
        static public int MaxRunningThreads => maxRunningThreads;
    }
}
