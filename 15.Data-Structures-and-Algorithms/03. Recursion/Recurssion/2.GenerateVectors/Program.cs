using System;

class Vectors01Generator
{
    static void Main()
    {
        int number = 5;

        int[] vector = new int[number];

        Generate01(number - 1, vector);
    }

    private static void Generate01(int index, int[] vector)
    {
        if(index == -1)
        {
            Print(vector);
        }

        else
        {
            for (int i = 0; i < 2; i++)
            {
                vector[index] = i;
                Generate01(index - 1, vector);
            }
        }
    }

    static void Print(int[] vector)
    {
        foreach (int v in vector)
        {
            Console.Write($"{v} ");
        }
        Console.WriteLine();
    }
}
