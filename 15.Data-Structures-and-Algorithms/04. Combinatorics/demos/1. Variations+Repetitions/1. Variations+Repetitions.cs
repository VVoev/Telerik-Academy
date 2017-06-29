using System;

namespace _1.Variations_Repetitions
{
    class Program
    {
        const int n = 10;
        const int k = 4;

        static string[] objects = new string[n]
        {
        "banana", "apple", "orange", "strawberry", "raspberry",
        "apricot", "cherry", "lemon", "grapes", "melon"
        };

        static int[] arr = new int[k];

        static void Main(string[] args)
        {
            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= arr.Length)
            {
                Print();
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write((i == arr.Length - 1) ? objects[arr[i]] : objects[arr[i]]+" ");
            }
            Console.WriteLine();
        }
    }
}
