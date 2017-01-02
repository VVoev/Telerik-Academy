using System;
using System.Linq;

class LargerThanNeighbours
{
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());

        double[] arrayOfNumbers = WriteNumbersInArray();

        int largerNeighbours = CountNumbersLargerThanNeighbours(arrayOfNumbers);

        Console.WriteLine(largerNeighbours);
    }
    static int CountNumbersLargerThanNeighbours(double[] numbers)
    {
        int countLargerNumbers = 0;

        for (int i = 1; i < numbers.Length - 1; i++)
        {
            double currentNumber = numbers[i];

            // Check for previous and next number is smaller than current number.
            bool isPreviousNumberSmaller = currentNumber > numbers[i - 1];
            bool isNextNumberSmaller = currentNumber > numbers[i + 1];
            bool isNumberLargerThanNeighbours = isPreviousNumberSmaller && isNextNumberSmaller;

            countLargerNumbers = UpdateNumberLargerThanNeighbours(countLargerNumbers, isNumberLargerThanNeighbours);
        }
        return countLargerNumbers;
    }

    static int UpdateNumberLargerThanNeighbours(int countLargerNumbers, bool isNumberLargerThanNeighbours)
    {
        if (isNumberLargerThanNeighbours)
        {
            countLargerNumbers++;
        }

        return countLargerNumbers;
    }

    static double[] WriteNumbersInArray()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(double.Parse)
                      .ToArray();
    }
}
