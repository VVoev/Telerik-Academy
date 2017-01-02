using System;
using System.Linq;

class AddingPolynomials
{
    static void Main()
    {
        int numberOfPolynomials = int.Parse(Console.ReadLine());

        int[] firstArray = WriteNumbersInArray();

        int[] secondArray = WriteNumbersInArray();

        int[] finalResultOfPolynomials = GetOperationOfPolynomials(firstArray, secondArray, numberOfPolynomials, "sum");

        PrintArray(finalResultOfPolynomials);
    }

    static void PrintArray(int[] sumOfPolynomials)
    {
        Console.WriteLine(string.Join(" ", sumOfPolynomials));
    }

    static int[] GetOperationOfPolynomials(int[] polynomialsOfFirst, int[] polynomialsOfSecond, int length, string typeOperation)
    {
        int[] result = new int[length];
        string[] polynomOperation = { "sum", "subtract", "multiplication" };
        for (int i = 0; i < length; i++)
        {
            switch (typeOperation)
            {
                case "sum":
                    result[i] = polynomialsOfFirst[i] + polynomialsOfSecond[i];
                    break;
                case "subtract":
                    result[i] = polynomialsOfFirst[i] - polynomialsOfSecond[i];
                    break;
                case "multiplicaiton":
                    result[i] = polynomialsOfFirst[i] * polynomialsOfSecond[i];
                    break;
                default:
                    result[i] = polynomialsOfFirst[i] + polynomialsOfSecond[i];
                    break;
            }
        }
        return result;
    }

    static int[] WriteNumbersInArray()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(int.Parse)
                      .ToArray();
    }
}
