using System;

namespace _04.Permutations
{
    using System.Linq;

    class Program
    {
        private static int[] arr;
        private static int n;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            arr = Enumerable.Range(1, n).ToArray();

            GeneratePermutations(arr, 0);
        }

        private static void GeneratePermutations(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr));
            }
            else
            {
                GeneratePermutations(arr, index + 1);
                for (int i = index + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[index], ref arr[i]);
                    GeneratePermutations(arr, index + 1);
                    Swap(ref arr[index], ref arr[i]);
                }
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
    }
}
