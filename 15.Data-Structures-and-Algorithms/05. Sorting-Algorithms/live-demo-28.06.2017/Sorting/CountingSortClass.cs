using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    static class CountingSortClass
    {
        public static void CountingSort(this int[] array, int minNumber, int maxNumber)
        {
            // [0; maxNumber]
            var counts = new int[maxNumber + 1 - minNumber];
            foreach (int x in array)
            {
                ++counts[x - minNumber];
            }

            int index = 0;
            for (int n = 0; n < counts.Length; ++n)
            {
                for (int i = 0; i < counts[n]; ++i)
                {
                    array[index] = n + minNumber;
                    ++index;
                }
            }
        }

        public static void RadixLeftToRight(this List<int> array, int digits, int base1)
        {
            int basePower = 1;
            for (int i = 1; i < digits; ++i)
            {
                basePower *= base1;
            }

            array.RadixLeftToRight(basePower, digits - 1, base1);
        }
        private static void RadixLeftToRight(this List<int> array, int basePower, int digit, int base1)
        {
            if (digit < 0)
            {
                return;
            }

            var buckets = new List<int>[base1];
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List<int>();
            }

            //var buckets = Enumerable.Range(0, base1)
            //    .Select(x => new List<int>())
            //    .ToArray();

            foreach (var x in array)
            {
                int currentDigit = x / basePower % base1;
                buckets[currentDigit].Add(x);
            }

            foreach (var bucket in buckets)
            {
                bucket.RadixLeftToRight(basePower / base1, digit - 1, base1);
            }

            int index = 0;
            foreach (var bucket in buckets)
            {
                foreach (var x in bucket)
                {
                    array[index] = x;
                    ++index;
                }
            }
        }

        public static void RadixRightToLeft(this int[] array, int digits, int base1)
        {
            var buckets = new List<int>[base1];
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List<int>();
            }

            // First digit sort
            foreach (var x in array)
            {
                int currentDigit = x % base1;
                buckets[currentDigit].Add(x);
            }

            int basePower = base1;

            for (int digit = 1; digit < digits; ++digit)
            {
                var newBuckets = new List<int>[base1];
                for (int i = 0; i < buckets.Length; ++i)
                {
                    newBuckets[i] = new List<int>();
                }

                foreach (var bucket in buckets)
                {
                    foreach (var x in bucket)
                    {
                        int currentDigit = x / basePower % base1;
                        newBuckets[currentDigit].Add(x);
                    }
                }

                basePower *= base1;
                buckets = newBuckets;
            }

            int index = 0;
            foreach (var bucket in buckets)
            {
                foreach (var x in bucket)
                {
                    array[index] = x;
                    ++index;
                }
                //bucket.Clear();
            }
        }
    }
}
