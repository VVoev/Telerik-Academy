using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargestAreaInMatrix
{
    static void Main()
    {
        // Variables for matrix size, row, col, type.
        int[] size = Console.ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToArray();
        int row = size[0];
        int col = size[1];
        int[,] matrix = new int[row, col];

        // Fill matrix cells read from console.
        FillMatrix(row, col, matrix);
        //PrintMatrix(row, col, matrix);

        int largestArea = 0;
        int maxLargestArea = int.MinValue;
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {
                if (matrix[x, y] == 0)
                {
                    continue;
                }
                int currentSearch = matrix[x, y];
                LookNeighbouringCells(row, col, matrix, ref largestArea, x, y, currentSearch);

                if (largestArea > maxLargestArea)
                {
                    maxLargestArea = largestArea;
                }
                largestArea = 1;
            }
        }
        Console.WriteLine(maxLargestArea);

    }

    private static void LookNeighbouringCells(int row, int col, int[,] matrix, ref int largestArea, int r, int c, int currentSearch)
    {
        if (matrix[r, c] == 0)
        {
            return;
        }
        matrix[r, c] = 0;
        //Console.WriteLine("-----------------------");
        //PrintMatrix(row, col, matrix);
        // Check for every direction. If true recursive call.
        if (r - 1 >= 0 && r - 1 <= row - 1 && matrix[r - 1, c] == currentSearch) // Direction UP.
        {
            largestArea++;
            LookNeighbouringCells(row, col, matrix, ref largestArea, (int)(r - 1), c, currentSearch);
        }
        if (c - 1 >= 0 && c - 1 <= col - 1 && matrix[r, c - 1] == currentSearch) // Direction LEFT.
        {
            largestArea++;
            LookNeighbouringCells(row, col, matrix, ref largestArea, r, (int)(c - 1), currentSearch);
        }
        if (r + 1 >= 0 && r + 1 <= row - 1 && matrix[r + 1, c] == currentSearch) // Direction DOWN.
        {
            largestArea++;
            LookNeighbouringCells(row, col, matrix, ref largestArea, (int)(r + 1), c, currentSearch);
        }

        if (c + 1 >= 0 && c + 1 <= col - 1 && matrix[r, c + 1] == currentSearch) // Direction RIGHT.
        {
            largestArea++;
            LookNeighbouringCells(row, col, matrix, ref largestArea, r, (int)(c + 1), currentSearch);
        }
        return;
    }

    static void FillMatrix(int row, int col, int[,] matrix)
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
    //static void PrintMatrix(int row, int col, int[,] matrix)
    //{
    //    for (int r = 0; r < row; r++)
    //    {
    //        for (int c = 0; c < col; c++)
    //        {
    //            Console.Write("{0} ", matrix[r, c]);
    //        }
    //        Console.WriteLine();
    //    }
    //}
}
