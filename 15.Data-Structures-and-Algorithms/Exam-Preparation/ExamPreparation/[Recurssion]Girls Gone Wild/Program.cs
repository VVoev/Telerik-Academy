using System;

class CombinationsGeneratorWithReps
{
    static int n = 0;
    static int k = 0;
    static string[] objects = new string[4]
    {
       "b","a","c","a"
    };
    static int[] arr;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());
        arr = new int[k];
        GenerateCombinationsNoRepetitions(0, 0);
    }

    static void GenerateCombinationsNoRepetitions(int index, int start)
    {
        if (index >= k)
        {
            PrintVariations();
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = i;
                GenerateCombinationsNoRepetitions(index + 1, i+1);
            }
        }
    }


    static void PrintVariations()
    {
        Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(objects[arr[i]] + " ");
        }
        Console.WriteLine(")");
    }
}