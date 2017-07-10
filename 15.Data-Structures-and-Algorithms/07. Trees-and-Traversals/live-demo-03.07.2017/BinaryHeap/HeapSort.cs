using System;

namespace BinaryHeap
{
    public static class BinaryHeapSort
    {
        public static void HeapSort<T>(this T[] array)
            where T: IComparable<T>
        {
            array.HeapSort((x, y) => x.CompareTo(y) > 0);
        }

        public static void HeapSort<T>(this T[] array, Func<T, T, bool> cmpFunc)
        {
            for (int i = array.Length / 2 - 1; i >= 0; --i)
            {
                array.HeapifyDown(cmpFunc, i, array[i], array.Length);
            }

            for (int i = array.Length - 1; i >= 0; --i)
            {
                var value = array[i];
                array[i] = array[0];
                array.HeapifyDown(cmpFunc, 0, value, i);
            }
        }
        private static void HeapifyDown<T>(this T[] heap, Func<T, T, bool> cmpFunc, int index, T value, int length)
        {
            while (index * 2 + 2 < length)
            {
                int smallerKidIndex = cmpFunc(heap[index * 2 + 1], heap[index * 2 + 2])
                    ? index * 2 + 1
                    : index * 2 + 2;
                if (cmpFunc(heap[smallerKidIndex], value))
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
                if (cmpFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }
}
