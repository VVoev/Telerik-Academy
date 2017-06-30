using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Combinations_Repetitions
{
    class Program
    {
        const int n = 5;
        const int k = 3;

        static string[] objects = new string[n] { "banana", "apple", "orange", "strawberry", "raspberry" };
        static int[] arr = new int[k];

        static void Main()
        {
            GenerateAllCombinations(0);
        }

        private static void GenerateAllCombinations(int index)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateAllCombinations(index + 1);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.Write(string.Join(" ", arr) + "=>");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write((objects[arr[i]] + " "));
            }

            Console.WriteLine();
        }
    }
}
