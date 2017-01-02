using System;

class SelectionSort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        // Add numbers read from console to array.
        AddNumbers(n, array);

        // Selection sort algorythm. In each iteration finds smallest number and put it on first position.
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int cnt = i; cnt < array.Length - 1; cnt++)
            {
                if (array[cnt + 1] < array[i])
                {
                    int temp = array[i];
                    array[i] = array[cnt + 1];
                    array[cnt + 1] = temp;
                }
            }
        }
        Console.WriteLine(string.Join(Environment.NewLine, array));
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
