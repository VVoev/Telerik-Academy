using System;
using System.Linq;

class GreatestCommonDivider
{
    static void Main()
    {
        int[] arrayNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        // Get absolute value of numbers.
        int firstNumber = Math.Abs(arrayNums[0]);
        int secondNumber = Math.Abs(arrayNums[1]);
        int GUD = 0;

        while (secondNumber != 0)
        {
            GUD = secondNumber;
            secondNumber = firstNumber % secondNumber;
            firstNumber = GUD;
        }
        Console.WriteLine(firstNumber);
    }
}
