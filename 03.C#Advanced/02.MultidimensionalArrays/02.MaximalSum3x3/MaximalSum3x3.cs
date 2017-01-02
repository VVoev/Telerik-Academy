using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSum3x3
{
    static void Main()
    {
        int[] size = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

        int row = size[0];
        int col = size[1];
        int[,] matrix = new int[row, col];
        int maxSum3X3 = int.MinValue;
        int currentSum3X3 = 0;
        int sizeMatrix = 3;

        FillMatrix(row, col, matrix);

        for (int r = 0; r < row - sizeMatrix + 1; r++)
        {
            for (int c = 0; c < col - sizeMatrix + 1; c++)
            {
                currentSum3X3 = CalculateCurrentSum(matrix, currentSum3X3, r, c, sizeMatrix);
                maxSum3X3 = UpdateMaxSum(maxSum3X3, currentSum3X3);
                currentSum3X3 = 0;
            }
        }
        Console.WriteLine(maxSum3X3);
    }

    private static int UpdateMaxSum(int maxSum3X3, int currentSum3X3)
    {
        if (maxSum3X3 < currentSum3X3)
        {
            maxSum3X3 = currentSum3X3;
        }

        return maxSum3X3;
    }

    private static int CalculateCurrentSum(int[,] matrix, int currentSum3X3, int r, int c, int sizeMatrix)
    {
        for (int row = r; row < r + sizeMatrix; row++)
        {
            for (int col = c; col < c + sizeMatrix; col++)
            {
                currentSum3X3 += matrix[row, col];
            }
        }
        return currentSum3X3;
    }

    private static void FillMatrix(int row, int col, int[,] matrix)
    {
        for (int r = 0; r < row; r++)
        {
            int[] input = Console.ReadLine()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();
            for (int c = 0; c < col; c++)
            {
                matrix[r, c] = input[c];
            }
        }
    }
}
