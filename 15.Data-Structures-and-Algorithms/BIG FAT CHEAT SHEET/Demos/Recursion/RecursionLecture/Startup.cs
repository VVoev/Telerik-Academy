using System;

namespace RecursionLecture
{
    public class Startup
    {
        public static void Main()
        {
            var labrynthSolver = new LabrynthPathSolver();
            var labrynth = new bool[,]
            {
                {false, false, false, true, false, false, false },
                {true, true, false, true, false, true, false },
                {false, false, false, false, false, false, false },
                {false, true, true, true, true, true, false },
                {false, false, false, false, false, false, false },
            };

            var possiblePaths = labrynthSolver.GetPossiblePaths(labrynth);

            foreach (var path in possiblePaths)
            {
                PrintMatrix(path);
            }
        }

        public static void PrintMatrix<T>(T[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static int count = 0;

        public static void SolveQueensProblem(bool[,] board, int[,] occupied, int columnIndex)
        {
            if (columnIndex == 8)
            {
                count++;
                return;
            }

            for (int rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                if (occupied[rowIndex, columnIndex] == 0)
                {
                    board[rowIndex, columnIndex] = true;
                    MarkOccupied(occupied, +1, rowIndex, columnIndex);

                    SolveQueensProblem(board, occupied, columnIndex + 1);

                    MarkOccupied(occupied, -1, rowIndex, columnIndex);
                    board[rowIndex, columnIndex] = false;
                }
            }
        }

        public static void MarkOccupied(int[,] occupied, int value, int rowIndex, int colIndex)
        {
            for (int i = 0; i < occupied.GetLength(0); i++)
            {
                occupied[rowIndex, i] += value;
                occupied[i, colIndex] += value;

                if (rowIndex + i < occupied.GetLength(0) && colIndex + i < occupied.GetLength(0))
                {
                    occupied[rowIndex + i, colIndex + i] += value;
                }

                if (rowIndex - i >= occupied.GetLength(0) && colIndex + i < occupied.GetLength(0))
                {
                    occupied[rowIndex - i, colIndex + i] += value;
                }
            }
        }
    }
}
