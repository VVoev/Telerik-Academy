using System;
using System.Linq;
using System.Numerics;

namespace _01.HelpDoge
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = line[0];
            int cols = line[1];

            var matrix = ReadMatrix(rows, cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var fromUp = row > 0 ? matrix[row - 1, col] : 0;
                    var fromLeft = col > 0 ? matrix[row, col - 1] : 0;

                    var toAdd = matrix[row, col] + Math.Max(fromUp, fromLeft);
                    matrix[row, col] = toAdd;
                }
            }

            Console.WriteLine(matrix[rows - 1, cols - 1]);
            // PrintMatrix(matrix, rows, cols);
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[line[0], line[1]]++;
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}