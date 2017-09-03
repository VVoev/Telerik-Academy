using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    public class Program
    {
        static int rows;
        static int cols;

        public static void Main()
        {
            var startCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startRow = startCoordinates[0];
            int startCol = startCoordinates[1];

            var matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = matrixDimensions[0];
            cols = matrixDimensions[1];

            var matrix = ReadMatrix();

            Solve(matrix, new bool[rows, cols], startRow, startCol, 0);
            Console.WriteLine(max);
        }

        static int max = 0;

        public static void Solve(int[,] matrix, bool[,] visited, int row, int col, int current)
        {
            if (!IsInRange(row, rows) || !IsInRange(col, cols) || matrix[row, col] == -1)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            var initialValue = matrix[row, col];

            if ((!IsInRange(row + initialValue, rows) || matrix[row + initialValue, col] == -1) &&
                (!IsInRange(row - initialValue, rows) || matrix[row - initialValue, col] == -1) &&
                (!IsInRange(col + initialValue, cols) || matrix[row, col + initialValue] == -1) &&
                (!IsInRange(col - initialValue, cols) || matrix[row, col - initialValue] == -1))
            {
                return;
            }

            current += matrix[row, col];
            max = Math.Max(current, max);

            visited[row, col] = true;

            // rows
            Solve(matrix, visited, row + initialValue, col, current);
            Solve(matrix, visited, row - initialValue, col, current);

            // cols
            Solve(matrix, visited, row, col + initialValue, current);
            Solve(matrix, visited, row, col - initialValue, current);

            visited[row, col] = false;
        }

        public static bool IsInRange(int current, int max)
        {
            return current >= 0 && current < max;
        }

        public static int[,] ReadMatrix()
        {
            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentMatrixRow = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentMatrixRow[j] == "#" ? -1 : int.Parse(currentMatrixRow[j]);
                }
            }

            return matrix;
        }

        public static void PrintMatrix<T>(T[,] matrix)
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