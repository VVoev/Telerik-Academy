using System;
using System.Linq;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());

        double[] arrayOfNumbers = WriteNumbersInArray();
    
        int indexOfNumber = FindFirstIndexWithSmallerNeighbours(arrayOfNumbers);

        Console.WriteLine(indexOfNumber);
    }
    static int FindFirstIndexWithSmallerNeighbours(double[] numbers)
    {
        int index = -1;

        for (int i = 1; i < numbers.Length - 1; i++)
        {
            double currentNumber = numbers[i];

            // Check for previous and next number is smaller than current number.
            bool isPreviousNumberSmaller = currentNumber > numbers[i - 1];
            bool isNextNumberSmaller = currentNumber > numbers[i + 1];
            bool isNumberLargerThanNeighbours = isPreviousNumberSmaller && isNextNumberSmaller;
            if (isNumberLargerThanNeighbours)
            {
                index = i;
                return index;
            }
        }
        return index;
    }

    static double[] WriteNumbersInArray()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(double.Parse)
                      .ToArray();
    }
}
