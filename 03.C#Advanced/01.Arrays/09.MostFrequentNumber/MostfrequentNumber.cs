using System;

class MostfrequentNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        // Add numbers read from console to array.
        AddNumbers(n, array);
        Array.Sort(array);
        int best = int.MinValue;
        int current = 1;
        int frequent = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                current++;
            }
            else
            {
                current = 1;
            }
            if (current > best)
            {
                best = current;
                frequent = array[i];
            }
        }
        if (n == 1)
        {
            Console.WriteLine("{0} (1 times)", array[0]);
        }
        else
        {
            Console.WriteLine("{0} ({1} times)", frequent, best);
        }
    }
    private static void AddNumbers(int n, int[] array)
    {
        for (int i = 0; i < n; i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            array[i] = currentNum;
        }
    }
}
