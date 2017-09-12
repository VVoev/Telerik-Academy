using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace RecursionDemo
{
    public class Program
    {
        static void Main()
        {
            PrintCombinations(49, 6);
        }

        static void PrintPermutations(int n)
        {
            PrintVariations(n, n);
        }

        static void PrintVariations(int n, int k)
        {
            var variation = new int[k];
            var used = new bool[n];
            PrintPermutations(0, variation, used);
        }

        static void PrintPermutations(int i, int[] permutation, bool[] used)
        {
            int n = used.Length;
            int k = permutation.Length;

            if (i == k)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for(int j = 0; j < n; ++j)
            {
                if(used[j])
                {
                    continue;
                }

                permutation[i] = j + 1;
                used[j] = true;
                PrintPermutations(i + 1, permutation, used);
                used[j] = false; // important
            }
        }

        static void PrintCombinations(int n, int k)
        {
            var combination = new int[k];
            PrintCombinations(0, n, combination);
        }

        static void PrintCombinations(int i, int n, int[] combination)
        {
            int k = combination.Length;

            if (i == k)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            var start = i == 0 ? 1 : combination[i - 1] + 1;
            for(int j = start; j <= n; ++j)
            {
                combination[i] = j;
                PrintCombinations(i + 1, n, combination);
            }
        }

    }
}
