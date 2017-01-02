using System;
using System.Linq;

class AppearanceCount
{
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());

        double[] arrayOfNumbers = WriteNumbersInArray();

        double numberToCompare = double.Parse(Console.ReadLine());

        int appearancesCount = GetNumberAppearances(numberToCompare, arrayOfNumbers);

        Console.WriteLine(appearancesCount);
    }

    static double[] WriteNumbersInArray()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(double.Parse)
                      .ToArray();
    }

    static int GetNumberAppearances(double numberAppearance, double[] numbers)
    {
        int appearance = 0;
        foreach (var number in numbers)
        {
            if (number == numberAppearance)
            {
                appearance++;
            }
        }
        return appearance;
    }
}
