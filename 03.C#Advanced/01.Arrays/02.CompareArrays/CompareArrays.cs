using System;

class CompareArrays
{
    static void Main()
    {
        // Read numbers from console into two arrays.
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[n];
        ReadNumbersInArray(firstArray);
        ReadNumbersInArray(secondArray);

        // Compating the two arrays.
        bool numberIsNotEqual = false;
        numberIsNotEqual = ComparingArrays(n, firstArray, secondArray, numberIsNotEqual);

        // Print result.
        PrintResultOfComparing(numberIsNotEqual);
    }

    private static void PrintResultOfComparing(bool numberIsNotEqual)
    {
        if (numberIsNotEqual)
        {
            Console.WriteLine("Not equal");
        }
        else
        {
            Console.WriteLine("Equal");
        }
    }

    private static bool ComparingArrays(int n, int[] firstArray, int[] secondArray, bool numberIsNotEqual)
    {
        for (int i = 0; i < n; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                numberIsNotEqual = true;

                break;
            }
        }

        return numberIsNotEqual;
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
