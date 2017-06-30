using System;

namespace _5.Combinations_No_Reps
{
    class Program
    {
        const int n = 5;
        const int k = 3;

        static string[] objects = new string[n] { "banana", "apple", "orange", "strawberry", "raspberry" };
        static int[] arr = new int[k];

        static void Main()
        {
            GenerateAllCombinations(0,0);
        }

        private static void GenerateAllCombinations(int index,int start)
        {
            if(index >=k)
            {
                Print(arr);
            }

            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateAllCombinations(index + 1,i+1);
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
