using System;
using System.Linq;

namespace _03.SortList
{
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the numbers separated by space or comma.");
            var list =
                Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var list1 = new List<int>();
            list1.AddRange(list);
            // Lomuto partiotion scheme
            QuickSortLomuto(list, 0, list.Count - 1);
            QuickSortHoare(list1, 0, list1.Count - 1);

            Console.WriteLine("Sorted with quick sort using Lomuto sheme: {0}", string.Join(", ", list));
            Console.WriteLine("Sorted with quick sort using Hoare  sheme: {0}", string.Join(", ", list1));
        }

        private static void QuickSortLomuto(List<int> list, int low, int high)
        {
            if (low < high)
            {
                var p = PartitionLomuto(list, low, high);
                QuickSortLomuto(list, low, p - 1);
                QuickSortLomuto(list, p + 1, high);
            }
        }

        private static void QuickSortHoare(List<int> list, int low, int high)
        {
            if (low < high)
            {
                var p = PartitionHoare(list, low, high);
                QuickSortHoare(list, low, p);
                QuickSortHoare(list, p + 1, high);
            }
        }

        private static int PartitionHoare(List<int> list, int low, int high)
        {
            var pivot = list[low];
            var i = low - 1;
            var j = high + 1;
            while (true)
            {
                do
                {
                    j--;
                } while (list[j] > pivot);
                do
                {
                    i++;
                } while (list[i] < pivot);

                if (i < j)
                {
                    Swap(list, i, j);
                }
                else
                {
                    return j;
                }
            }
        }
        private static int PartitionLomuto(List<int> list, int low, int high)
        {
            int pivot = list[high];
            var i = low;

            for (int j = low; j < high; j++)
            {
                if (list[j] <= pivot)
                {
                    Swap(list, i, j);
                    i = i + 1;
                }
            }
            Swap(list, i, high);
            return i;
        }

        private static void Swap(List<int> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}