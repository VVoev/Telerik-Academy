using SortingAlgorithms.ArrayExtensions;
using System;

namespace SortingAlgorithms
{
    public class Startup
    {
        public static void Main()
        {
            var elements = new int[] { 100, 120, 60, 128, 80, 121, 121, 127, 126 };
            elements = elements.SelectionSort();
            // elements = elements.BubbleSort();
            // elements = elements.InsertionSort();
            // elements = elements.QuickSort();
            // elements.QuickSortInPlace(0, elements.Length);
            // elements.MergeSort();
            // elements.MergeSort();
            // elements.CountSort(128);
            // elements.CountSort(0, 128);
            // elements.BinarySearchSort();

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}