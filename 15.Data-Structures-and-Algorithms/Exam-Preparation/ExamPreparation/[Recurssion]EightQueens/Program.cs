using System;

namespace _Recurssion_EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Eight Queen Problem");
            QueenSolver solver = new QueenSolver(12);
            var result = solver.FindAllSolutions();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total Combinations of {0}",result);
        }
    }

    class QueenSolver
    {
        byte[,] queens;
        private int counter = 0;

        public QueenSolver(int size)
        {
            this.queens = new byte[size, size];
        }

        public int FindAllSolutions()
        {
            Resurssion(0);
            return this.counter;
        }

        private void Resurssion(int row)
        {
            if (row >= this.queens.GetLength(0))
            {
                this.counter++;
                Print(this.counter);
                return;
            }

            for (int col = 0; col < this.queens.GetLength(0); col++)
            {
                if (this.queens[row, col] == 0)
                {
                    this.queens[row, col] += 1;
                    MarkQueen(row, col);
                    Resurssion(row + 1);

                    this.queens[row, col] -= 1;
                    UnmarkQueen(row, col);
                }
            }
        }

        private void Print(int counter)
        {
            Console.WriteLine($"-------- Variant {counter} --------------");
            for (int row = 0; row < this.queens.GetLength(0); row++)
            {
                for (int col = 0; col < this.queens.GetLength(1); col++)
                {
                    if (this.queens[row, col] == 4)
                    {
                        Console.Write("Q"+" ");
                    }
                    else
                    {
                        Console.Write("X"+" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void UnmarkQueen(int row, int col)
        {
            for (int i = row; i < this.queens.GetLength(0); i++)
            {
                this.queens[i, col] -= 1;
                if (col + (i - row) < this.queens.GetLength(0))
                {
                    this.queens[i, col + (i - row)] -= 1;
                }
                if (col - (i - row) >= 0)
                {
                    this.queens[i, col - (i - row)] -= 1;
                }
            }
        }

        private void MarkQueen(int row, int col)
        {
            for (int i = row; i < this.queens.GetLength(0); i++)
            {
                this.queens[i, col] += 1;
                if (col + (i - row) < this.queens.GetLength(0))
                {
                    this.queens[i, col + (i - row)] += 1;
                }
                if (col - (i - row) >= 0)
                {
                    this.queens[i, col - (i - row)] += 1;
                }
            }
        }
    }
}
