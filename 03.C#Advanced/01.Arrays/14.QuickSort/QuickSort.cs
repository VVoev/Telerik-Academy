using System;

class QuickSort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbersToSort = new int[n];

        // Read numbers from console.
        ReadNumbersInArray(numbersToSort);

        // Implementation of quicksort algorithm.
        QuickSortAlgorithm(numbersToSort, 0, numbersToSort.Length - 1);

        // Print sorted array.
        Console.WriteLine(string.Join(Environment.NewLine, numbersToSort));

    }
    private static void QuickSortAlgorithm(int[] numbers, int start, int end)
    {
        int left = start;
        int right = end;
        int position = numbers[(start + end) / 2];
        while (left <= right)
        {
            while (numbers[left] < position)
            {
                left++;
            }
            while (numbers[right] > position)
            {
                right--;
            }
            if (left <= right)
            {
                int temp = numbers[left];
                numbers[left] = numbers[right];
                numbers[right] = temp;
                left++;
                right--;
            }
        }
        if (start < right)
        {
            QuickSortAlgorithm(numbers, start, right);
        }
        if (end > left)
        {
            QuickSortAlgorithm(numbers, left, end);

        }

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