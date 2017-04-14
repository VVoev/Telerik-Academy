using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions_Homework.Utilities
{
   public static class Utils
    {
        public static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "First Number to swap is Null");
            Debug.Assert(y != null, "Second Number to swap is Null");

            T oldX = x;
            x = y;
            y = oldX;
        }


        public static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The Array is null");
            Debug.Assert(arr.Length != 0, "The Array is emptry");
            Debug.Assert(startIndex > endIndex, "Start Index is bigger then endIndex");
            Debug.Assert(endIndex < arr.Length, "End Index is bigger then ArraySize");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }
    }
}
