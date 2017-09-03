using System;

namespace TreesAndTreeTraversals.HeapSort
{
    public static class HeapSortArrayExtension
    {
        public static void HeapSort<T>(this T[] heap, Func<T, T, bool> compareFunc)
        {
            Console.WriteLine(string.Join(", ", heap));

            for (int i = heap.Length - 1; i >= 0; i--)
            {
                heap.HeapifyDown(compareFunc, i, heap.Length);
            }

            for (int i = heap.Length - 1; i >= 0; i--)
            {
                T value = heap[0];
                heap[0] = heap[i];
                heap[i] = value;

                heap.HeapifyDown(compareFunc, 0, i);
            }

            Console.WriteLine(string.Join(", ", heap));
        }

        public static void HeapifyDown<T>(this T[] heap, Func<T, T, bool> compareFunc, int index, int length)
        {
            T value = heap[index];

            while (index * 2 + 2 < length)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;

                int smallerChildIndex = compareFunc(heap[leftChildIndex], heap[rightChildIndex]) ?
                    leftChildIndex : rightChildIndex;

                if (compareFunc(heap[smallerChildIndex], value))
                {
                    heap[index] = heap[smallerChildIndex];
                }
                else
                {
                    break;
                }

                index = smallerChildIndex;
            }

            if (index * 2 + 1 < length)
            {
                int smallerChildIndex = index * 2 + 1;

                if (compareFunc(heap[smallerChildIndex], value))
                {
                    heap[index] = heap[smallerChildIndex];
                    index = smallerChildIndex;
                }
            }

            heap[index] = value;
        }
    }
}
