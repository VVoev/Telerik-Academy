using System;
using System.Linq;

class SequenceInMatrix
{
    static void Main()
    {
        // Variables for matrix size, row, col, type.
        short[] size = Console.ReadLine()
                           .Split(' ')
                           .Select(short.Parse)
                           .ToArray();
        short row = size[0];
        short col = size[1];
        string[,] matrix = new string[row, col];

        // Fill matrix cells read from console.
        FillMatrix(row, col, matrix);

        // Variables to find max sequence in matrix.
        short maxSum = short.MinValue;
        short horizontalSum = 1;
        short verticalSum = 1;
        short diagonalSum = 1;

        // Horizontal max sequence.
        FindBestHorizontalSequence(row, col, matrix, ref maxSum, ref horizontalSum);

        // Vertical max sequence.
        FindBestVerticalSequence(row, col, matrix, ref maxSum, ref verticalSum);
        
        // From bottom left to top right.
        FindBestRightDiagonal(row, col, matrix, ref maxSum, ref diagonalSum);
        
        // From top left to bottom right.
        FindBestLeftDiagonal(row, col, matrix, ref maxSum, ref diagonalSum);

        // Print max sequence.
        Console.WriteLine(maxSum);
    }

    static void FindBestLeftDiagonal(short row, short col, string[,] matrix, ref short maxSum, ref short diagonalSum)
    {
        for (int leftDiag = 0; leftDiag < row + col - 1; ++leftDiag)
        {
            int z1 = leftDiag < col ? 0 : leftDiag - col + 1;
            int z2 = leftDiag < row ? 0 : leftDiag - row + 1;
            diagonalSum = 0;
            string wanted = matrix[leftDiag - z2, z2];
            for (int j = leftDiag - z2; j >= z1; --j)
            {
                if (matrix[j, leftDiag - j] == wanted)
                {
                    diagonalSum++;
                }
                else
                {
                    diagonalSum = 1;
                }
                maxSum = UpdateMaxSum(maxSum, diagonalSum);
                wanted = matrix[j, leftDiag - j];
            }
        }
    }

    static void FindBestRightDiagonal(short row, short col, string[,] matrix, ref short maxSum, ref short diagonalSum)
    {
        for (int rightDiag = 0; rightDiag < row + col - 1; ++rightDiag)
        {
            int z1 = rightDiag < col ? 0 : rightDiag - col + 1;
            int z2 = rightDiag < row ? 0 : rightDiag - row + 1;
            diagonalSum = 0;
            string wanted = matrix[row - 1 - rightDiag + z2, row - 1 - rightDiag + z2 + (rightDiag - row + 1)];
            for (int j = (row - 1) - rightDiag + z2; j <= (row - 1) - z1; j++)
            {
                if (matrix[j, j + (rightDiag - row + 1)] == wanted)
                {
                    diagonalSum++;
                }
                else
                {
                    diagonalSum = 1;
                }
                maxSum = UpdateMaxSum(maxSum, diagonalSum);
                wanted = matrix[j, j + (rightDiag - row + 1)];
            }
        }
    }

    static void FindBestHorizontalSequence(short row, short col, string[,] matrix, ref short maxSum, ref short horizontalSum)
    {
        for (short r = 0; r < row; r++)
        {
            for (short c = 1; c < col; c++)
            {
                if (matrix[r, c - 1] == matrix[r, c])
                {
                    horizontalSum++;
                }
                else
                {
                    horizontalSum = 1;
                }
                maxSum = UpdateMaxSum(maxSum, horizontalSum);
            }
        }
    }

    static void FindBestVerticalSequence(short row, short col, string[,] matrix, ref short maxSum, ref short verticalSum)
    {
        for (short c = 0; c < col; c++)
        {
            for (short r = 1; r < row; r++)
            {
                if (matrix[r - 1, c] == matrix[r, c])
                {
                    verticalSum++;
                }
                else
                {
                    verticalSum = 1;
                }
                maxSum = UpdateMaxSum(maxSum, verticalSum);
            }
        }
    }

    static short UpdateMaxSum(short maxSum, short currentSum)
    {
        if (maxSum < currentSum)
        {
            maxSum = currentSum;
        }

        return maxSum;
    }

    static void FillMatrix(short row, short col, string[,] matrix)
    {
        for (short r = 0; r < row; r++)
        {
            string[] input = Console.ReadLine()
                                 .Split(' ')
                                 .ToArray();
            for (short c = 0; c < col; c++)
            {
                matrix[r, c] = input[c];
            }
        }
    }
}
