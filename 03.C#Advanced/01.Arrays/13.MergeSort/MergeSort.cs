using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MergeSort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbersToSort = new int[n];
        ReadNumbersInArray(numbersToSort);
        int[] sortedNumbers = MergeSorting(numbersToSort);
        Console.WriteLine(string.Join(Environment.NewLine, sortedNumbers));
    }
    private static int[] MergeSorting(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }

        List<int> leftArray = new List<int>();
        List<int> rightArray = new List<int>();
        int middle = array.Length / 2;

        for (int i = 0; i < array.Length; i++)
        {
            if (i < middle)
            {
                leftArray.Add(array[i]);
            }
            else
            {
                rightArray.Add(array[i]);
            }
        }

        leftArray = MergeSorting(leftArray.ToArray()).ToList();
        rightArray = MergeSorting(rightArray.ToArray()).ToList();

        return Merge(leftArray,rightArray);
    }
    private static int[] Merge(List<int> leftArray, List<int> rightArray)
    {
        List<int> result = new List<int>();

        while (leftArray.Count > 0 && rightArray.Count > 0)
        {
            if (leftArray.ElementAt(0) <= rightArray.ElementAt(0))
            {
                result.Add(leftArray.ElementAt(0));
                leftArray.RemoveAt(0);
            }
            else
            {
                result.Add(rightArray.ElementAt(0));
                rightArray.RemoveAt(0);
            }
        }

        while (leftArray.Count > 0)
        {
            result.Add(leftArray.ElementAt(0));
            leftArray.RemoveAt(0);
        }
        while (rightArray.Count > 0)
        {
            result.Add(rightArray.ElementAt(0));
            rightArray.RemoveAt(0);
        }
        return result.ToArray();
    }
    private static void ReadNumbersInArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            numbers[i] = currentNumber;
        }
    }
}
