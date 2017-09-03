using System;

namespace _04.GeneratePermutations
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var used = new bool[n + 1];
            var permutation = new int[n];
            PrintPermutations(permutation, used, 0);
        }

        public static void PrintPermutations(int[] permutation, bool[] used, int index)
        {
            if (index == permutation.Length)
            {
                Console.WriteLine(string.Join(", ", permutation));
                return;
            }

            for (int i = 1; i <= permutation.Length; i++)
            {
                if (!used[i])
                {
                    permutation[index] = i;
                    used[i] = true;

                    PrintPermutations(permutation, used, index + 1);

                    used[i] = false;
                }
            }
        }
    }
}
