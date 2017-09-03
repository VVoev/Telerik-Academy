using System;

namespace LargestConnectedArea
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new char[,]
            {
                {' ', ' ', '*', ' ' },
                {' ', ' ', '*', ' ' },
                {' ', ' ', '*', ' '}
            };

            int maxAdjacentElementsCount = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        int fromCurrentCellAdjacentEmptyElements = FindLargestConnectedAreaOfAdjacentElements(matrix, i, j);

                        if (fromCurrentCellAdjacentEmptyElements > maxAdjacentElementsCount)
                        {
                            maxAdjacentElementsCount = fromCurrentCellAdjacentEmptyElements;
                        }
                    }
                }
            }

            Console.WriteLine(maxAdjacentElementsCount);
        }

        public static int FindLargestConnectedAreaOfAdjacentElements(char[,] matrix, int rowIndex, int colIndex)
        {
            if (!IsCellInRange(rowIndex, colIndex, matrix.GetLength(0), matrix.GetLength(1)))
            {
                return 0;
            }

            if (matrix[rowIndex, colIndex] != ' ')
            {
                return 0;
            }

            matrix[rowIndex, colIndex] = '-';

            int rightNeighboursCount = FindLargestConnectedAreaOfAdjacentElements(matrix, rowIndex, colIndex + 1);
            int downNeighboursCount = FindLargestConnectedAreaOfAdjacentElements(matrix, rowIndex + 1, colIndex);

            int leftNeighboursCount = FindLargestConnectedAreaOfAdjacentElements(matrix, rowIndex, colIndex - 1);
            int upNeighboursCount = FindLargestConnectedAreaOfAdjacentElements(matrix, rowIndex - 1, colIndex);

            int totalNeighboursCount = leftNeighboursCount + rightNeighboursCount + upNeighboursCount + downNeighboursCount + 1;
            return totalNeighboursCount;
        }

        private static bool IsCellInRange(int rowIndex, int colIndex, int rowsCount, int colsCount)
        {
            return rowIndex >= 0 &&
                rowIndex < rowsCount &&
                colIndex >= 0 &&
                colIndex < colsCount;
        }
    }
}