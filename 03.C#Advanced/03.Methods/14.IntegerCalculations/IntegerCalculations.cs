using System;
using System.Linq;
using System.Numerics;

class IntegerCalculations
{
    static void Main()
    {
        int[] numbersToCalculate = WriteNumbersInArray();

        decimal[] calculations = GetResultOfCalculation(numbersToCalculate);
        PrintResult(calculations);
    }

    static void PrintResult(decimal[] calculations)
    {
        for (int i = 0; i < calculations.Length; i++)
        {
            if (i == 2)
            {
                Console.WriteLine("{0:F2}", calculations[i]);
            }
            else
            {
                Console.WriteLine(calculations[i]);
            }
        }
    }

    static decimal[] GetResultOfCalculation(int[] numbers)
    {
        decimal[] calcResult = new decimal[5];
        int min = int.MaxValue;
        int max = int.MinValue;
        decimal avg = 0.0m;
        long sum = 0;
        long product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNumber = numbers[i];
            sum = CalculateSum(sum, currentNumber);
            avg = CalculateAverage(sum, i);
            product = CalculateProduct(product, currentNumber);
            max = FindMaxValue(max, currentNumber);
            min = FindMinValue(min, currentNumber);
        }
        WriteResultInArray(calcResult, min, max, avg, sum, product);
        return calcResult;
    }

    static long CalculateSum(long sum, int currentNumber)
    {
        sum += currentNumber;
        return sum;
    }

    static decimal CalculateAverage(long sum, int i)
    {
        return sum / (decimal)(i + 1);
    }

    static long CalculateProduct(long product, int currentNumber)
    {
        product *= currentNumber;
        return product;
    }

    static int FindMaxValue(int max, int currentNumber)
    {
        if (max < currentNumber)
        {
            max = currentNumber;
        }

        return max;
    }

    static int FindMinValue(int min, int currentNumber)
    {
        if (min > currentNumber)
        {
            min = currentNumber;
        }

        return min;
    }

    static void WriteResultInArray(decimal[] calcResult, int min, int max, decimal avg, long sum, long product)
    {
        calcResult[0] = min;
        calcResult[1] = max;
        calcResult[2] = avg;
        calcResult[3] = sum;
        calcResult[4] = product;
    }

    static int[] WriteNumbersInArray()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(int.Parse)
                      .ToArray();
    }
}
