using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        ReadNumbersInArray(array);
        int longestSequence = 1;
        int bestSequence = 1;
        for (int i = 1; i < n; i++)
        {
            if (array[i] == array[i - 1])
            {
                longestSequence++;
            }
            else
            {
                longestSequence = 1;
            }
            if (bestSequence < longestSequence)
            {
                bestSequence = longestSequence;
            }
        }
        Console.WriteLine(bestSequence);
    }
    private static void ReadNumbersInArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            array[i] = currentNumber;
        }
    }
}
