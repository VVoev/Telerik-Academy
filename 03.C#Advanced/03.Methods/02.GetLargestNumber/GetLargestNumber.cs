
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GetLargestNumber
{
    static void Main()
    {
        int[] numbersToCompare = WriteNumbers();

        int max = GetMax(numbersToCompare);

        Console.WriteLine(max);
    }

    static int[] WriteNumbers()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(int.Parse)
                      .ToArray();
    }
    // The method is working for more than 3 numbers.
    static int GetMax(int[] numbers)
    {
        int biggestNumber = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNumber = numbers[i];
            if (currentNumber > biggestNumber)
            {
                biggestNumber = currentNumber;
            }
        }
        return biggestNumber;
    }
}