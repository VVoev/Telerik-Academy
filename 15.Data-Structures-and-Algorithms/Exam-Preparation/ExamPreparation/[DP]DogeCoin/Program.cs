using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DP_DogeCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int cointValue = 1;
            var input = Console.ReadLine().Split(' ').ToArray();
            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);
            var matrix = new int[rows, cols];

            var numberOfCoins = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCoins; i++)
            {
                var cordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var rowCord = cordinates[0];
                var colCord = cordinates[1];
                    matrix[rowCord, colCord]++;
            }
            var dp = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int maxAbove = 0;
                    int MaxLeft = 0;

                    if (row - 1 >= 0)
                    {
                        maxAbove = dp[row-1, col];
                    }
                    if (col - 1 >= 0)
                    {
                        MaxLeft = dp[row, col - 1];
                    }

                    dp[row, col] = Math.Max(maxAbove, MaxLeft) + matrix[row, col];
                }
            }

            Console.WriteLine(dp[rows-1,cols-1]);


           

        }
    }
}
