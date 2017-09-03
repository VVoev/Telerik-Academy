using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPassableAreasInMatrix
{
    public class StartUp
    {
        private const char PassableChar = 'x';
        private const char NonPassableChar = '*';

        public static void Main()
        {
            var matrix = new char[,]
            {
                { '1', 'x', '2', '2', '2', 'x' },
                { 'x', 'x', 'x', '2', '4', 'x' },
                { '4', 'x', '1', '2', 'x', 'x' },
                { '4', 'x', '1', '2', '1', '1' },
                { '4', 'x', '1', 'x', 'x', 'x' }
            };

            List<Coordinates> pathList;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == PassableChar)
                    {
                        pathList = new List<Coordinates>();

                        FindPassableAreas(matrix, pathList, i, j);

                        if (pathList.Count > 0)
                        {
                            Print(pathList);
                        }
                    }
                }
            }
        }

        public static void FindPassableAreas(char[,] matrix, IList<Coordinates> pathCoordinates, int rowIndex, int colIndex)
        {
            if (!IsCellValid(rowIndex, colIndex, matrix.GetLength(0), matrix.GetLength(1)))
            {
                return;
            }

            if (matrix[rowIndex, colIndex] != PassableChar)
            {
                return;
            }

            matrix[rowIndex, colIndex] = NonPassableChar;
            pathCoordinates.Add(new Coordinates() { Row = rowIndex, Col = colIndex });

            FindPassableAreas(matrix, pathCoordinates, rowIndex, colIndex + 1);
            FindPassableAreas(matrix, pathCoordinates, rowIndex + 1, colIndex);
            FindPassableAreas(matrix, pathCoordinates, rowIndex, colIndex - 1);
            FindPassableAreas(matrix, pathCoordinates, rowIndex - 1, colIndex);
        }

        public static bool IsCellValid(int rowIndex, int colIndex, int rowsCount, int colsCount)
        {
            return rowIndex >= 0 && rowIndex < rowsCount && colIndex >= 0 && colIndex < colsCount;
        }

        public static void Print(List<Coordinates> elements)
        {
            Console.WriteLine(string.Join(" => ", elements.Select(e => $"({e.Row}, {e.Col})")));
        }
    }

    public class Coordinates
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }
}