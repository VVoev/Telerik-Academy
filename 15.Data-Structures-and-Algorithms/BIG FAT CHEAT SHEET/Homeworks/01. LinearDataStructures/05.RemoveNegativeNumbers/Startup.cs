using System.Collections.Generic;

namespace RemoveNegativeNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, -5, -2, 3, -100 };
            RemoveNegativeNumbers(numbers);

            System.Console.WriteLine(string.Join(", ", numbers));
        }

        private static void RemoveNegativeNumbers(IList<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
