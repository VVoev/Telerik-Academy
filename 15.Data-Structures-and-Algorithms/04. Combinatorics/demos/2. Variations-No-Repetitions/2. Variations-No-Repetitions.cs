using System;

namespace _2.Variations_No_Repetitions
{
    class Program
    {
        const int n = 10;
        const int k = 3;

        static string[] objects = new string[n]
        {
        "banana", "apple", "orange", "strawberry", "raspberry",
        "apricot", "cherry", "lemon", "grapes", "melon"
        };

        static int[] arr = new int[k];

        static void Main(string[] args)
        {
            GenerateVariantsNoRepetition(0,0);
        }

        private static void GenerateVariantsNoRepetition(int index,int start)
        {
            if(index >= arr.Length)
            {
                Print();
            }

            else
            {
                for (int i = start; i < n; i++)
                {

                    arr[index] = i;
                    if (index > 0)
                    {
                        if(arr[index] != arr[index - 1])
                        {
                            GenerateVariantsNoRepetition(index + 1, start + 1);
                        }
                    }

                    else
                    {
                        GenerateVariantsNoRepetition(index + 1, start + 1);

                    }
                }
            }
        }

        private static void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write((i == arr.Length - 1) ? objects[arr[i]] : objects[arr[i]] + " ");
            }
            Console.WriteLine();
        }
    }
}
