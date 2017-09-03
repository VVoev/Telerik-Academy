using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LongestCommonSubsequence
{
    class Program
    {
        static void Main()
        {
            string first = "BCABD";
            string second = "CAD";

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
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            BuildLongestSubsequence(dp, string.Empty, first, second, first.Length, second.Length);
        }

        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void BuildLongestSubsequence(int[,] dp,string subsequence, string first, string second, int row, int col)
        {
            if (row == 0 || col == 0)
            {
                Console.WriteLine(subsequence);
                return;
            }

            if (first[row - 1] == second[col - 1])
            {
                BuildLongestSubsequence(dp, subsequence + first[row - 1], first, second, row - 1, col - 1);
            }
            else if (dp[row, col - 1] > dp[row - 1, col])
            {
                BuildLongestSubsequence(dp, subsequence, first, second, row, col - 1);
            }
            else if (dp[row, col - 1] < dp[row - 1, col])
            {
                BuildLongestSubsequence(dp, subsequence, first, second, row - 1, col);
            }
            else
            {
                BuildLongestSubsequence(dp, subsequence, first, second, row, col - 1);
                BuildLongestSubsequence(dp, subsequence, first, second, row - 1, col);
            }
        }

        public static string BuildLongestSubsequence(int[,] dp, string first, string second)
        {
            string subsequence = string.Empty;

            int row = first.Length;
            int col = second.Length;

            while (row > 0 && col > 0)
            {
                if (first[row - 1] == second[col - 1])
                {
                    subsequence = first[row - 1] + subsequence;
                    --row;
                    --col;
                }
                else if (dp[row - 1, col] > dp[row, col - 1])
                {
                    --col;
                }
                else
                {
                    --row;
                }
            }

            return subsequence;
        }
    }
}
