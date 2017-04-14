using System;
using System.Diagnostics;

namespace Assertions_Homework.SearchingAlgorithms
{
    public static  class SearchingAlgo
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The Array is null");
            Debug.Assert(arr.Length != 0, "The Array is emptry");
            Debug.Assert(arr.Length != 1, "The Array is already sorted");

            Debug.Assert(value != null, "Searched Value is Null");

            Debug.Assert(startIndex > endIndex, "Start Index is bigger then endIndex");
            Debug.Assert(endIndex < arr.Length, "End Index is bigger then ArraySize");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
