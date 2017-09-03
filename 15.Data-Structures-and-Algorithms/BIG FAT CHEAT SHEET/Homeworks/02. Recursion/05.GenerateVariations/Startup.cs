using System;

namespace _05.GenerateVariations
{
    public class Startup
    {
        static string[] words = new string[]
        {
            "hi",
            "a",
            "b"
        };

        public static void Main()
        {
            Console.Write("k:");
            int k = int.Parse(Console.ReadLine());

            int n = words.Length;    
            var used = new bool[words.Length];
            var permutation = new string[k];

            //PrintVariationsWithoutRepetition(permutation, used, 0);
            PrintVariationsWithRepetition(permutation, 0, n);
        }

        public static void PrintVariationsWithoutRepetition(string[] permutation, bool[] used, int index)
        {
            if (index == permutation.Length)
            {
                Console.WriteLine(string.Join(", ", permutation));
                return;
            }

            for (int i = 0; i < used.Length; i++)
            {
                if (!used[i])
                {
                    permutation[index] = words[i];
                    used[i] = true;

                    PrintVariationsWithoutRepetition(permutation, used, index + 1);

                    used[i] = false;
                }
            }
        }

        public static void PrintVariationsWithRepetition(string[] permutation, int index, int n)
        {
            if (index == permutation.Length)
            {
                Console.WriteLine(string.Join(", ", permutation));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                permutation[index] = words[i];
                PrintVariationsWithRepetition(permutation, index + 1, n);
            }
        }
    }
}
