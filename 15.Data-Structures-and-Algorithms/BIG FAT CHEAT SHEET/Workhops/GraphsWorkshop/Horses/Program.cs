using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horses
{
    public class Program
    {
        static int minCount = int.MaxValue;

        static int n;
        static bool[,] visited;

        static Cell startCell;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            visited = new bool[n, n];

            var matrix = ReadMatrix(n);

            var deltaRow = new int[] { 2, 2, -2, -2, 1, -1, 1, -1 };
            var deltaCol = new int[] { -1, 1, 1, -1, 2, 2, -2, -2, };

            var q = new Queue<Cell>();
            q.Enqueue(startCell);


            while (q.Count > 0)
            {
                var currentPoint = q.Dequeue();
                visited[currentPoint.Row, currentPoint.Col] = true;

                for (int i = 0; i < deltaRow.Length; i++)
                {
                    var newRow = currentPoint.Row + deltaRow[i];
                    var newCol = currentPoint.Col + deltaCol[i];

                    if (IsInRange(newRow, newCol, n) && matrix[newRow, newCol] != 'x' && !visited[newRow, newCol])
                    {
                        if (matrix[newRow, newCol] == 'e')
                        {
                            Console.WriteLine(currentPoint.Steps + 1);
                            return;
                        }

                        var newCell = new Cell(newRow, newCol, currentPoint.Steps + 1);
                        visited[newCell.Row, newCell.Col] = true;
                        q.Enqueue(newCell);
                    }
                }
            }

            Console.WriteLine("No");
        }

        public static char[,] ReadMatrix(int n)
        {
            var matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == "s")
                    {
                        startCell = new Cell(i, j, 0);
                    }

                    matrix[i, j] = char.Parse(line[j]);
                }
            }

            return matrix;
        }

        public static bool IsInRange(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }

    public class Cell
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Steps { get; set; }

        public Cell(int row, int col, int steps)
        {
            this.Row = row;
            this.Col = col;
            this.Steps = steps;
        }
    }
}
