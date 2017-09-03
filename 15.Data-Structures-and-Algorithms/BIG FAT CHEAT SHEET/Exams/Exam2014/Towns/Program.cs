﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Towns
//{
//    public class Program
//    {
//        static int LongestBitonicSubsequence(int[] arr, int n)
//        {
//            int i, j;

//            /* Allocate memory for LIS[] and initialize LIS values as 1 for
//                all indexes */
//            int[] lis = new int[n];
//            for (i = 0; i < n; i++)
//                lis[i] = 1;

//            /* Compute LIS values from left to right */
//            for (i = 1; i < n; i++)
//                for (j = 0; j < i; j++)
//                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
//                        lis[i] = lis[j] + 1;

//            /* Allocate memory for lds and initialize LDS values for
//                all indexes */
//            int[] lds = new int[n];
//            for (i = 0; i < n; i++)
//                lds[i] = 1;

//            /* Compute LDS values from right to left */
//            for (i = n - 2; i >= 0; i--)
//                for (j = n - 1; j > i; j--)
//                    if (arr[i] > arr[j] && lds[i] < lds[j] + 1)
//                        lds[i] = lds[j] + 1;


//            /* Return the maximum value of lis[i] + lds[i] - 1*/
//            int max = lis[0] + lds[0] - 1;
//            for (i = 1; i < n; i++)
//                if (lis[i] + lds[i] - 1 > max)
//                    max = lis[i] + lds[i] - 1;

//            return max;
//        }

//        public static void Main(string[] args)
//        {
//            int townsCount = int.Parse(Console.ReadLine());
//            var arr = new int[townsCount];

//            for (int i =0; i < arr.Length; i++)
//            {
//                var line = Console.ReadLine().Split(' ');
//                arr[i] = int.Parse(line[0]);
//            }

//            int n = arr.Length;

//            var result = LongestBitonicSubsequence(arr, n);
//            Console.WriteLine(result);
//        }
//    }
//}

using System;
using System.Linq;

namespace Towns
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int townscount = int.Parse(Console.ReadLine());
            var arr = new int[townscount];

            for (int i = 0; i < arr.Length; i++)
            {
                var line = Console.ReadLine().Split(' ');
                arr[i] = int.Parse(line[0]);
            }

            var result = LongestBitonicSubsequence(arr);
            Console.WriteLine(result);
        }

        public static int LongestBitonicSubsequence(int[] numbers)
        {
            int[] lis = Enumerable.Range(0, numbers.Length).Select(_ => 1).ToArray();

            for (int i = 1; i < lis.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                    }
                }
            }

            int[] lisReverse = Enumerable.Range(0, numbers.Length).Select(_ => 1).ToArray();

            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                for (int j = numbers.Length - 1; j > i; j++)
                {
                    if (numbers[j] < numbers[i])
                    {
                        lisReverse[i] = Math.Max(lisReverse[j] + 1, lisReverse[i]);
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                max = Math.Max(max, lis[i] + lisReverse[i] - 1);
            }

            return max;
        }
    }
}
