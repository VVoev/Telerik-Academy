using Assertions_Homework.Utilities;
using System;
using System.Diagnostics;

namespace Assertions_Homework.SortingAlgorithms
{
    public static class SortingAlgo
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The Array is null");
            Debug.Assert(arr.Length != 0, "The Array is emptry");
            Debug.Assert(arr.Length != 1, "The Array is already sorted");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = Utils.FindMinElementIndex(arr, index, arr.Length - 1);
                Utils.Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }
    }
}
