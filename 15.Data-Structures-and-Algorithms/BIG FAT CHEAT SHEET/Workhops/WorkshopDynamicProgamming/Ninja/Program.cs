using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(n);
            var dp = new int[n, n];
            dp[0, 0] = 2;

            for (int i = 1; i < n; i++)
            {
                var prev = dp[0, i - 1];
                bool hasLight = prev % 2 == 0 ? matrix[0, i] : !matrix[0, i];

                dp[0, i] = hasLight ? prev + 1 : prev + 2;

                prev = dp[i - 1, 0];
                hasLight = prev % 2 == 0 ? matrix[i, 0] : !matrix[i, 0];
                dp[i, 0] = hasLight ? prev + 1 : prev + 2;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    var fromUp = dp[i - 1, j];
                    bool hasLight = fromUp % 2 == 0 ? matrix[i, j] : !matrix[i, j];

                    var fromUpResult = hasLight ? fromUp + 1 : fromUp + 2;

                    var fromLeft = dp[i, j - 1];
                    hasLight = fromLeft % 2 == 0 ? matrix[i, j] : !matrix[i, j];
                    var fromLeftResult = hasLight ? fromLeft + 1 : fromLeft + 2;

                    dp[i, j] = Math.Min(fromLeftResult, fromUpResult);
                }
            }

            Console.WriteLine(dp[n - 1, n - 1] - 1);

            // PrintMatrix(dp);
        }

        public static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool[,] ReadMatrix(int n)
        {
            var matrix = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == "1")
                    {
                        matrix[i, j] = true;
                    }
                }
            }

            return matrix;
        }
    }
}