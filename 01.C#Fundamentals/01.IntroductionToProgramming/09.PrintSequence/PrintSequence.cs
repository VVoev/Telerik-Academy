using System;

class PrintSequence
{
    static void Main()
    {
        int[] sequence = new int[10] { 2, -3, 4, -5, 6, -7, 8, -9, 10, -11 };
        for (int i = 0; i < sequence.Length; i++)
        {
            Console.WriteLine(sequence[i]);
        }
    }
}
