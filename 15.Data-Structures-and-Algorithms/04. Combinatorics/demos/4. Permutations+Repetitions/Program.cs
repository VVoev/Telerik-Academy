using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Permutations_Repetitions
{
    class Program
    {
        static string[] array;

        static void Main(string[] args)
        {
            array = new string[] { "Petar", "Ivan", "Kolio", "Kolio","Venc","Pavel" };
            Array.Sort(array);
            GenerateWithRepetitions(array, 0, array.Length);
        }

        private static void GenerateWithRepetitions(string[] arr, int start, int n)
        {
            Print(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        GenerateWithRepetitions(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        private static void Swap<T>(ref T v1, ref T v2)
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static void Print<T>(T[] array)
        {
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
