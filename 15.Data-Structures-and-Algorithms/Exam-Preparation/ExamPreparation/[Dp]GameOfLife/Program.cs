using System;
using System.Linq;

namespace _Dp_GameOfLife
{
    class Program
    {
        static int rows;
        static int cols;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < matrixSize.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        //check right and down and rightdown
                    }
                    if (row == 0)
                    {

                    }
                    if(col == 0)
                    {

                    }
                }
            }



            Print(matrix);
        }

        private static void CheckForMultiPly(int cell, int[,] matrix)
        {
            throw new NotImplementedException();
        }

        private static void Print(int[,] matrix)
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
    }
}
