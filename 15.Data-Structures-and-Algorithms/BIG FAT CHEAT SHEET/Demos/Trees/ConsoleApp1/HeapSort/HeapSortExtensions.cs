using System;

namespace ConsoleApp1.HeapSort
{
    public static class HeapSortExtensions
    {
        public static void HeapSort<T>(this T[] heap, Func<T, T, bool> compareFunc)
        {
            for (int i = heap.Length / 2 - 1; i >= 0; i--)
            {
                heap.HeapifyDown(i, heap[i], compareFunc, heap.Length);
            }

            for (int i = heap.Length - 1; i >= 0; i--)
            {
                var value = heap[i];
                heap[i] = heap[0];
                heap.HeapifyDown(0, value, compareFunc, i);
            }
        }

        public static void HeapifyDown<T>(this T[] heap, int initialIndex, T value, Func<T, T, bool> compareFunc, int length)
        {
            int index = initialIndex;
            while (index * 2 + 2 < length)
            {
                int leftKidIndex = index * 2 + 1;
                int rightKidIndex = index * 2 + 2;

                int smallerKidIndex = compareFunc(heap[leftKidIndex], heap[rightKidIndex]) ?
                        leftKidIndex : rightKidIndex;

                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 + 1 < length)
            {
                int smallerKidIndex = index * 2 + 1;

                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }
}