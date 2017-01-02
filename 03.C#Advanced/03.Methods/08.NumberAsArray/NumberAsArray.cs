using System;
using System.Linq;

class NumberAsArray
{
    static void Main()
    {
        // Read size of arrays.
        int[] sizeArrays = ReadNumbers();

        // Get max length of arrays.
        int maxLength = Math.Max(sizeArrays[0], sizeArrays[1]) + 1;
        int[] firstArray = new int[maxLength];
        int[] secondArray = new int[maxLength];

        int[] nums = ReadNumbers();
        int[] nums2 = ReadNumbers();

        // Fill all digits in array.
        FillNumbers(maxLength, firstArray, nums);
        FillNumbers(maxLength, secondArray, nums2);

        int[] sumArrays = new int[maxLength];
        sumArrays = GetSumOfTwoArrays(firstArray, secondArray, sumArrays.Length);
        PrintResult(maxLength, sumArrays);
    }

    static void PrintResult(int maxLength, int[] sumArrays)
    {
        for (int i = 0; i < maxLength; i++)
        {
            if (i == maxLength - 1 && sumArrays[i] == 0)
            {
                continue;
            }
            Console.Write(sumArrays[i] + " ");
        }
        Console.WriteLine();
    }

    static void FillNumbers(int maxLength, int[] firstArray, int[] nums)
    {
        for (int i = 0; i < maxLength; i++)
        {
            if (i >= nums.Length)
            {
                continue;
            }
            firstArray[i] = nums[i];
        }
    }

    static int[] ReadNumbers()
    {
        return Console.ReadLine()
                                  .Split(' ')
                                  .Select(int.Parse)
                                  .ToArray();
    }

    static int[] GetSumOfTwoArrays(int[] first, int[] second, int length)
    {
        int[] finalArray = new int[length];
        int currentDigit = 0;
        int remainder = 0;

        for (int i = 0; i < length; i++)
        {
            if (i == 0)
            {
                finalArray[i] = (first[i] + second[i]) % 10;
            }
            else
            {
                currentDigit = (first[i] + second[i]) % 10 + (first[i - 1] + second[i - 1]) / 10;

                finalArray[i] = (currentDigit + remainder) % 10;
            }
            remainder = UpdateRemainder(currentDigit, remainder);

        }
        return finalArray;
    }

    static int UpdateRemainder(int currentDigit, int remainder)
    {
        if (currentDigit + remainder > 9)
        {
            remainder = 1;
        }
        else
        {
            remainder = 0;
        }

        return remainder;
    }
}