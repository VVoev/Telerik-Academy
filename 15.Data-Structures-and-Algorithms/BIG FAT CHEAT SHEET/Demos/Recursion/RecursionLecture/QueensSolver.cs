using System.Collections.Generic;

namespace RecursionLecture
{
    public class QueensSolver
    {
        private List<bool[,]> resultBoards;
        private int count;

        public List<bool[,]> GetQueensProblemSolutions(int boardSize)
        {
            this.resultBoards = new List<bool[,]>();
            this.count = 0;

            SolveQueensProblem(new bool[boardSize, boardSize], new int[boardSize, boardSize], 0);
            System.Console.WriteLine(this.count);
            return resultBoards;
        }

        private void SolveQueensProblem(bool[,] board, int[,] occupied, int columnIndex)
        {
            if (columnIndex == board.GetLength(0))
            {
                this.AddBoard(board);
                this.count++;

                return;
            }

            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                if (occupied[rowIndex, columnIndex] == 0)
                {
                    board[rowIndex, columnIndex] = true;
                    MarkOccupied(occupied, 1, rowIndex, columnIndex);

                    SolveQueensProblem(board, occupied, columnIndex + 1);

                    board[rowIndex, columnIndex] = false;
                    MarkOccupied(occupied, -1, rowIndex, columnIndex);
                }
            }
        }

        private void MarkOccupied(int[,] occupied, int value, int rowIndex, int colIndex)
        {
            for (int i = 0; i < occupied.GetLength(0); i++)
            {
                occupied[i, colIndex] += value;
                occupied[rowIndex, i] += value;

                if (rowIndex + i < occupied.GetLength(0) && colIndex + i < occupied.GetLength(0))
                {
                    occupied[rowIndex + i, colIndex + i] += value;
                }

                if (rowIndex - i >= 0 && colIndex + i < occupied.GetLength(0))
                {
                    occupied[rowIndex - i, colIndex + i] += value;
                }
            }
        }

        private void AddBoard(bool[,] board)
        {
            var boardToAdd = new bool[board.GetLength(0), board.GetLength(1)];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    boardToAdd[row, col] = board[row, col];
                }
            }

            this.resultBoards.Add(boardToAdd);
        }
    }
}
