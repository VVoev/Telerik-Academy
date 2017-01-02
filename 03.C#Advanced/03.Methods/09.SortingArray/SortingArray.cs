using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortingArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] unsortedNumbers = WriteNumbersInArray();

        // Print array in ascending order.
        int[] ascendingArray = SortAscending(unsortedNumbers);
        Console.WriteLine(string.Join(" ", ascendingArray));

        // Print array in descending order.
        //int[] descendingArray = SortDescending(ascendingArray);
        //Console.WriteLine(string.Join(" ", descendingArray));
    }
    static int[] SortAscending(int[] numbers)
    {
        int[] ascending = new int[numbers.Length];
        int min = int.MaxValue;
        for (int i = 0, j = 0, index = 0; j < ascending.Length; i++)
        {
            int current = numbers[i];
            GetCurrentMinNumber(ascending, ref min, i, j, ref index, current);
            UpdateIndexAscendingPosition(numbers, ascending, ref min, ref i, ref j, index);
        }
        return ascending;
    }

    static int[] SortDescending(int[] numbers)
    {
        int[] descending = new int[numbers.Length];
        int max = int.MinValue;
        for (int i = 0, j = 0, index = 0; j < descending.Length; i++)
        {
            int current = numbers[i];
            GetCurrentMaxNumber(descending, ref max, i, j, ref index, current);
            UpdateIndexDescendingPosition(numbers, descending, ref max, ref i, ref j, index);
        }
        return descending;
    }

    static void UpdateIndexAscendingPosition(int[] numbers, int[] ascending, ref int min, ref int i, ref int j, int index)
    {
        if (i == ascending.Length - 1)
        {
            numbers[index] = int.MaxValue;
            j++;
            i = -1;
            min = int.MaxValue;
        }
    }

    static void UpdateIndexDescendingPosition(int[] numbers, int[] descending, ref int max, ref int i, ref int j, int index)
    {
        if (i == descending.Length - 1)
        {
            numbers[index] = int.MinValue;
            j++;
            i = -1;
            max = int.MinValue;
        }
    }

    static void GetCurrentMinNumber(int[] ascending, ref int min, int i, int j, ref int index, int current)
    {
        if (current < min)
        {
            min = current;
            ascending[j] = min;
            index = i;
        }
    }

    static void GetCurrentMaxNumber(int[] descending, ref int max, int i, int j, ref int index, int current)
    {
        if (current > max)
        {
            max = current;
            descending[j] = max;
            index = i;
        }
    }



    static int[] WriteNumbersInArray()
    {
        return Console.ReadLine()
                      .Split(' ')
                      .Select(int.Parse)
                      .ToArray();
    }
}
