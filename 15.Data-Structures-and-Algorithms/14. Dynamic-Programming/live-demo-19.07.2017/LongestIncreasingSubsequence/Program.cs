using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main()
        {
            //var array = new int[] { 1, 8, 2, 7, 3, 4, 1, 6, 2 };
            //var array = new int[] { 3, 1, 2, 4 };
            var array = new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };

            GenIncreasingSubseqs(array);

            var minLastElement = new List<int> { -1 };
            var prevElement = new int[array.Length];
            for (int i = 0; i < prevElement.Length; ++i)
            {
                prevElement[i] = -1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                var left = 1;
                var right = minLastElement.Count;

                while (left < right)
                {
                    var middle = (left + right) / 2;
                    if (array[minLastElement[middle]] < array[i])
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle;
                    }
                }

                if (left < minLastElement.Count)
                {
                    if (array[minLastElement[left]] > array[i])
                    {
                        minLastElement[left] = i;
                    }
                }
                else
                {
                    minLastElement.Add(i);
                }

                prevElement[i] = minLastElement[left - 1];
            }

            Console.WriteLine(minLastElement.Count - 1);
            Console.WriteLine(string.Join(" ", prevElement));
            Console.WriteLine(string.Join(" ", minLastElement));

            var subsequence = new List<int>();

            for (int index = minLastElement[minLastElement.Count - 1];
                            index >= 0;
                            index = prevElement[index])
            {
                subsequence.Add(array[index]);
            }

            subsequence.Reverse();
            Console.WriteLine(string.Join(" ", subsequence));
        }

        static void GenIncreasingSubseqs(int[] array)
        {
            GenIncreasingSubseqs(array, -1, new List<int>());
        }

        static void GenIncreasingSubseqs(int[] array, int lastIndex, List<int> subseq)
        {
            //Console.WriteLine(string.Join(" ", subseq));

            for (int i = lastIndex + 1; i < array.Length; i++)
            {
                if (lastIndex < 0 || array[lastIndex] < array[i])
                {
                    subseq.Add(array[i]);
                    GenIncreasingSubseqs(array, i, subseq);
                    subseq.RemoveAt(subseq.Count - 1);
                }
            }
        }
    }
}
