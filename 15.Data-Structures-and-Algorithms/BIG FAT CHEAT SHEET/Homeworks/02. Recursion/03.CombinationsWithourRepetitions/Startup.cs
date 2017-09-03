using System;

namespace _03.CombinationsWithourRepetitions
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            GetCombinations(new int[k], 0, 1, n);
        }

        public static void GetCombinations(int[] combination, int index, int startFrom, int end)
        {
            if (index == combination.Length)
            {
                Console.WriteLine(string.Join(", ", combination));
                return;
            }

            for (int i = startFrom; i <= end; i++)
            {
                combination[index] = i;
                GetCombinations(combination, index + 1, i + 1, end);
            }
        }
    }
}
