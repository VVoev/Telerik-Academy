using System;

namespace _12.EightQueensPuzzle
{
    public class Startup
    {
        private static int possibleArrangementsCount = 0;

        public static void Main()
        {
            int chessBoardSize = 8;
            var queensPosition = new bool[chessBoardSize, chessBoardSize];
            var visited = new int[chessBoardSize, chessBoardSize];

            SolveQueenPuzzle(queensPosition, visited, 0);
            Console.WriteLine(possibleArrangementsCount);
        }

        public static void SolveQueenPuzzle(bool[,] queensPositions, int[,] visited, int colIndex)
        {
            if (colIndex == queensPositions.GetLength(0))
            {
                possibleArrangementsCount++;
                PrintQueensPositions(queensPositions);
                return;
            }

            for (int rowIndex = 0; rowIndex < queensPositions.GetLength(0); rowIndex++)
            {
                if (visited[rowIndex, colIndex] == 0)
                {
                    queensPositions[rowIndex, colIndex] = true;
                    MarkVisited(visited, 1, rowIndex, colIndex);

                    SolveQueenPuzzle(queensPositions, visited, colIndex + 1);

                    queensPositions[rowIndex, colIndex] = false;
                    MarkVisited(visited, -1, rowIndex, colIndex);

                }
            }
        }

        public static void MarkVisited(int[,] visited, int value, int rowIndex, int colIndex)
        {
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                visited[rowIndex, i] += value;
                visited[i, colIndex] += value;

                if (rowIndex + i < visited.GetLength(0) && colIndex + i < visited.GetLength(1))
                {
                    visited[rowIndex + i, colIndex + i] += value;
                }

                if (rowIndex - i >= 0 && colIndex + i < visited.GetLength(1))
                {
                    visited[rowIndex - i, colIndex + i] += value;
                }
            }
        }

        public static void PrintQueensPositions(bool[,] queensPositions)
        {
            for (int row = 0; row < queensPositions.GetLength(0); row++)
            {
                for (int col = 0; col < queensPositions.GetLength(1); col++)
                {
                    Console.Write(queensPositions[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
