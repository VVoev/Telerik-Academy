using System;
using System.Collections.Generic;

namespace _04.LongestSubsequenceOfEqualElement
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>() { 1, 2, 2, 2, 2, 3, 4, 4, 5, 5, 5, 2, 8,8,8,8,8,8,8,8,8,8 };
            var maxOccurences = FindLongestSubsequence(numbers);
            Console.WriteLine(maxOccurences);
        }

        private static int FindLongestSubsequence(IList<int> numbers)
        {
            int maxOccurences = 0;
            int currentOccurences = 1;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int currentNumber = numbers[i];
                int nextNumber = numbers[i + 1];
                if (currentNumber == nextNumber)
                {
                    currentOccurences++;
                    if (currentOccurences > maxOccurences)
                    {
                        maxOccurences = currentOccurences;
                    }
                }
                else
                {
                    if (currentOccurences > maxOccurences)
                    {
                        maxOccurences = currentOccurences;
                    }

                    currentOccurences = 1;
                }
            }

            return maxOccurences;
        }
    }
}
