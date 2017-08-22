using System;
using System.Collections.Generic;

namespace _Combinatorics_ZigZag
{
    class Program
    {
        static List<int> AllNumbers = new List<int>();
        static int[] array;
        static int counter = 0;
        static int k;
        static int n;
        static bool[] used;
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            k = int.Parse(input[1]);
            used = new bool[n];
            array = new int[k];

            GenerateVariationsNoReps(0);
            Console.WriteLine(counter);


        }

        static void GenerateVariationsNoReps(int index)
        {
            if (index >= k)
            {
                PrintVariations();
                return;
            }
            else
                for (int i = 0; i < n; i++)
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariationsNoReps(index + 1);
                        used[i] = false;
                    }
        }

        private static void PrintVariations()
        {
            bool isZigZag = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (array[i] > array[i + 1])
                    {
                        continue;
                    }
                    else
                    {
                        isZigZag = false;
                        break;
                    }
                }
                if (i % 2 == 1)
                {
                    if (array[i] < array[i + 1])
                    {
                        continue;
                    }
                    else
                    {
                        isZigZag = false;
                        break;
                    }
                }
            }

            if (isZigZag)
            {
                counter++;
            }

        }
    }
}
