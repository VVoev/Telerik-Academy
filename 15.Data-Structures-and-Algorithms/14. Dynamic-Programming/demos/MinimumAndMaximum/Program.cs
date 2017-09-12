namespace MinimumAndMaximum
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var numbers = new[] { 1, 101, 1337, -10, 0 };
            Console.WriteLine($"Max (stupid): {FindMaxStupid(numbers)}");
            Console.WriteLine($"Max (LINQ): {numbers.Max()}");
            Console.WriteLine($"Min: {FindMin(numbers)}");
            Console.WriteLine($"Max: {FindMax(numbers)}");
        }

        private static int FindMaxStupid(int[] numbers)
        {
            foreach (var number in numbers)
            {
                var currentNumberIsBest = true;
                foreach (var candidate in numbers)
                {
                    if (number < candidate)
                    {
                        currentNumberIsBest = false;
                    }
                }

                if (currentNumberIsBest)
                {
                    return number;
                }
            }

            return int.MinValue;
        }

        private static int FindMin(int[] numbers)
        {
            var min = numbers[0];
            for (var i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private static int FindMax(int[] numbers)
        {
            var max = numbers[0];
            for (var i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }
    }
}
