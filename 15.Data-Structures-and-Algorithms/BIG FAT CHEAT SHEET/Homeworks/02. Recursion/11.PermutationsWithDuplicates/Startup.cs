using System;
using System.Collections.Generic;

namespace _11.PermutationsWithDuplicates
{
    public class Startup
    {
        private static List<string> uniquePermutations = new List<string>();

        static int[] permutationsValues = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        public static void Main()
        {
            GetPermutations(permutationsValues.Length);

            Console.WriteLine(uniquePermutations.Count);
            foreach (var per in uniquePermutations)
            {
                Console.WriteLine(per);
            }
        }

        private static void GetPermutations(int depth)
        {
            if (depth == 1)
            {
                uniquePermutations.Add(string.Join(string.Empty, permutationsValues));
                return;
            }

            GetPermutations(depth - 1);

            for (int i = 0; i < depth - 1; i++)
            {
                if (permutationsValues[i] != permutationsValues[depth - 1])
                {
                    Swap(ref permutationsValues[i], ref permutationsValues[depth - 1]);
                    GetPermutations(depth - 1);
                    Swap(ref permutationsValues[i], ref permutationsValues[depth - 1]);
                }
            }
        }

        public static void Swap<T>(ref T firstElement, ref T secondElement)
        {
            T swapTemporaryValue = firstElement;
            firstElement = secondElement;
            secondElement = swapTemporaryValue;
        }
    }
}
