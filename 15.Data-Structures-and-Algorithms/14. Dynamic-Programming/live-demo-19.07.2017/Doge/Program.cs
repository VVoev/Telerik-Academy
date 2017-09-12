using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Doge
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new string[]
            {
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "                    ",
                "         @ @        ",
                "   @            @   ",
                "        @           ",
                "           @        ",
                "    @  @   @        ",
                "      @             ",
                "              @     ",
                "     @     @        ",
                "                   @",
                "                    "
            };

            var n = map.Length;
            var m = map[0].Length;

            var memo = new BigInteger[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    memo[i, j] = -1;
                }
            }
            var result = Dfs(map, memo, 0, 0);
            Console.WriteLine(result);


            Console.WriteLine(DP(map, n, m));
            Console.WriteLine(DPMemoryOptimized(map, n, m));
        }

        static BigInteger DPMemoryOptimized(string[] map, int n, int m)
        {
            var dp = new BigInteger[2, m];
            dp[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i > 0 ? dp[(i - 1) % 2, j] : 0;
                    var fromLeft = j > 0 ? dp[i % 2, j - 1] : 0;

                    dp[i % 2, j] = map[i][j] == ' '
                        ? fromUp + fromLeft
                        : 0;
                }
            }

            return dp[(n - 1) % 2, m - 1];
        }

        static BigInteger DP(string[] map, int n, int m)
        {
            var dp = new BigInteger[n, m];
            dp[0, 0] = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i > 0 ? dp[i - 1, j] : 0;
                    var fromLeft = j > 0 ? dp[i, j - 1] : 0;

                    dp[i, j] = map[i][j] == ' '
                        ? fromUp + fromLeft
                        : 0;
                }
            }

            return dp[n - 1, m - 1];
        }

        static BigInteger Dfs(string[] map, BigInteger[,] memo, int row, int col)
        {
            if (row >= map.Length || col >= map[row].Length)
            {
                return 0;
            }

            if (row == map.Length - 1
                && col == map[row].Length - 1)
            {
                //Console.WriteLine("Found a way");
                return 1;
            }

            if (map[row][col] != ' ')
            {
                return 0;
            }

            if (memo[row, col] < 0)
            {
                var down = Dfs(map, memo, row + 1, col);
                var right = Dfs(map, memo, row, col + 1);
                memo[row, col] = down + right;
            }

            return memo[row, col];
        }
    }
}
