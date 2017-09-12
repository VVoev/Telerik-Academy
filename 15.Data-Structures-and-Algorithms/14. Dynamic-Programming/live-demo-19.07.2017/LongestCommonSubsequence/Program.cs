using System;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main()
        {
            var first = "ABCBDAB";
            var second = "BDCABA";

            var dp = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            for (int i = 0; i <= first.Length; ++i)
            {
                for (int j = 0; j <= second.Length; ++j)
                {
                    Console.Write(" " + dp[i, j]);
                }

                Console.WriteLine();
            }

            Backtrack(first, second, dp);
        }

        static void Backtrack(string first, string second, int[,] dp)
        {
            Backtrack(first, second, dp, first.Length, second.Length, "");
        }

        static void Backtrack(string first, string second, int[,] dp, int i, int j, string subsequence)
        {
            if (i == 0 || j == 0)
            {
                Console.WriteLine(subsequence);
                return;
            }

            if (first[i - 1] == second[j - 1])
            {
                Backtrack(first, second, dp, i - 1, j - 1, first[i - 1] + subsequence);
            }
            else if (dp[i - 1, j] > dp[i, j - 1])
            {
                Backtrack(first, second, dp, i - 1, j, subsequence);
            }
            else if (dp[i - 1, j] < dp[i, j - 1])
            {
                Backtrack(first, second, dp, i, j - 1, subsequence);
            }
            else
            {
                Backtrack(first, second, dp, i - 1, j, subsequence);
                Backtrack(first, second, dp, i, j - 1, subsequence);
            }
        }
    }
}
